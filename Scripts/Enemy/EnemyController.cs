
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering.UI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    [SerializeField] EnemyAI EnemyAi;
    [SerializeField] GameObject TextPrefab;
    [SerializeField] GameObject PoisonEffect;
    [SerializeField] Slider HealthSlider;
    [SerializeField] GameObject ExplosionPrefab;
    [SerializeField] GameObject ExperincePrefab;
    public float enemyStamina = 100;
    public float maxStamina = 100;
    public float enemyHealth = 1000;
    public float maxHealth = 1000;
    public float Level;
    public float range = 5f;

    public float rotationSpeed = 5.0f;
    public Transform Enemy;
    public float GameTime = 0f;
    public float minutes = 0;

    public float attackThreshold = 15f;
    public bool isAttacking = false;
    private Transform playerTransform;
    public EnemyAI EnemyAI;
    private PlayerController playerController;
    private LevelsManager LevelsManager;
    private SkillsController SkillsController;
    private RandomEnemySpawn RandomEnemySpawn;
    private StatsController StatsController;
    private SettingController SettingController;
    private StatDisplay StatDisplay;
    public float DistanceToPlayer;
    public float angleDifference;
    public float HealthReturn;
    public float buffAmount = 0;
    public float ShotDelay = 0;
    public float AttackChance = 100;
    public float EnemyAttackRateMultiplier = 0.6f;
    public float EnemyProjectileSpeedMultiplier = 1;
    public bool IsBossEnemy = false;
    EnemyBossHealthBar EnemyBossHealthBar;
    float expTimeBuff = 0;
    float poisondamagelength = 1f;
    float EnemyBonusLevel = 0;
    bool ApplyOnce;


    void Start()
    {
        anim = GetComponent<Animator>();
        SkillTreeData skillData = SkillTreeData.Load();

        AttackChance = PlayerPrefs.GetFloat("EnemyAttackChance", 100);
        EnemyAttackRateMultiplier = PlayerPrefs.GetFloat("EnemyAttackRateMultiplier", 0.6f);
        EnemyProjectileSpeedMultiplier = PlayerPrefs.GetFloat("EnemyProjectileSpeedMultiplier", 1);
        EnemyBonusLevel = skillData.EnemyBonusLevel;
        GameObject player = GameObject.FindWithTag("Player");
        GameObject level = GameObject.FindWithTag("ui");
        GameObject EnemyGenerator = GameObject.FindWithTag("EnemySpawn");
        GameObject Stats = GameObject.FindGameObjectWithTag("Stats");

        if (player != null)
        {
            playerTransform = player.transform;
            playerController = player.GetComponent<PlayerController>();
            SkillsController = player.GetComponent<SkillsController>();
            StatsController = player.GetComponent<StatsController>();
            SettingController = player.GetComponent<SettingController>();

        }
        else
        {
            //Debug.LogError("Player GameObject not found! Make sure the Player is tagged as 'Player'.");
        }
        if (level != null)
        {
            LevelsManager = level.GetComponent<LevelsManager>();
            if (LevelsManager == null)
            {
                //Debug.LogError("LevelsManager component not found on the UI GameObject!");
            }
        }
        if (EnemyGenerator != null)
        {
            RandomEnemySpawn = EnemyGenerator.GetComponent<RandomEnemySpawn>();

            if (RandomEnemySpawn == null)
            {
                //Debug.Log("RandomEnemySpawn Component not found on the EnemyGenerator gameobject");
            }
        }
        if (Stats != null)
        {
            StatDisplay = Stats.GetComponent<StatDisplay>();
            if (StatDisplay == null)
            {
                //Debug.Log("couldn't find statDisplay on gameobject Stats");
            }
        }
        GameTime = RandomEnemySpawn.gameTime;
        minutes = RandomEnemySpawn.minutes;
        float LevelRange = EnemyBonusLevel + 5;
        Level = Random.Range(StatsController.currentLevel + EnemyBonusLevel - 5, StatsController.currentLevel + EnemyBonusLevel + LevelRange);



        if (Level >= 0)
        {
            for (int i = 0; i < Level; i++)
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    maxHealth /= 0.9f;
                    enemyHealth = maxHealth;
                    //Debug.Log($"Boosted Health: {maxHealth}");
                }
                if (random == 1)
                {
                    maxStamina /= 0.9f;
                    enemyStamina = maxStamina;
                    //Debug.Log($"Boosted Stamina: {maxStamina}");

                }
                if (random == 2)
                {
                    MissileDamage /= 0.9f;
                    NukeDamage /= 0.9f;
                    MinigunDamage /= 0.9f;
                    HomingMissileDamage /= 0.9f;
                    FlakDamage /= 0.9f;
                    DroneDamage /= 0.9f;
                    LaserDamage /= 0.9f;
                    //Debug.Log($"Boosted Damage: {MissileDamage} MD, {NukeDamage} ND, {MinigunDamage} MiD, {HomingMissileDamage} HMD, {FlakDamage} FD, {DroneDamage} DD, {LaserDamage} LD");
                }
            }
        }
        else if (Level < 0)
        {
            for (int i = 0; i > Level; i--)
            {
                int random = Random.Range(0, 5);

                if (random == 0)
                {
                    maxHealth *= 0.9f;
                    enemyHealth = maxHealth;
                    //Debug.Log($"Reduced Health: {maxHealth}");
                }
                if (random == 1)
                {
                    maxStamina *= 0.9f;
                    enemyStamina = maxStamina;
                    //Debug.Log($"Reduced Health: {maxStamina}");
                }
                if (random == 2)
                {
                    MissileDamage *= 0.9f;
                    NukeDamage *= 0.9f;
                    MinigunDamage *= 0.9f;
                    HomingMissileDamage *= 0.9f;
                    FlakDamage *= 0.9f;
                    DroneDamage *= 0.9f;
                    LaserDamage *= 0.9f;
                    //Debug.Log($"Reduced Damage: {MissileDamage} MD, {NukeDamage} ND, {MinigunDamage} MiD, {HomingMissileDamage} HMD, {FlakDamage} FD, {DroneDamage} DD, {LaserDamage} LD");
                }
                if (random == 3)
                {
                    EnemyAttackRateMultiplier += 0.1f;
                    //Debug.Log($"Changed Attack Rate: {EnemyAttackRateMultiplier}");
                }
                if (random == 4)
                {
                    EnemyProjectileSpeedMultiplier += 0.1f;
                    //Debug.Log($"Changed Projectile Speed: {EnemyProjectileSpeedMultiplier}");
                }
            }
        }
        Debug.Log($"Enemy Level {Level}");
        anim.enabled = (PlayerPrefs.GetInt("AnimationsActive") != 0);
        if (IsBossEnemy)
        {
            EnemyBossHealthBar = GameObject.FindWithTag("EnemyBossHealthBar").GetComponent<EnemyBossHealthBar>();
            EnemyBossHealthBar.ShowHealthBar();
        }
    }

    void Update()
    {
        GameTime = RandomEnemySpawn.gameTime;
        minutes = Mathf.FloorToInt(GameTime / 60);
        if (enemyHealth <= 0)
        {
            RandomEnemySpawn.KillCount += 1;
            RandomEnemySpawn.enemyCount -= 1;
            /*
            StatsController.currentXP += StatsController.ExpGain;
            Debug.Log("exp gain" + StatsController.ExpGain);
            */

            var Experince = Instantiate(ExperincePrefab, this.transform.position, this.transform.rotation);
            if (IsBossEnemy)
            {
                Experince.GetComponent<ExperincePointStat>().Experince = Random.Range(StatsController.ExpGain * 4, StatsController.ExpGain * 10);
                EnemyBossHealthBar.HideHealthBar();
                RandomEnemySpawn.DefeatedBoss();
            }
            else
            {
                Experince.GetComponent<ExperincePointStat>().Experince = Random.Range(StatsController.ExpGain * 0.75f, StatsController.ExpGain * 1.5f);
            }
            var Explosion = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);

            Destroy(gameObject);
        }

        if (playerTransform == null || Enemy == null)
        {
            //Debug.LogWarning("Player or Enemy transform is not assigned!");
            return;
        }

        DistanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        Vector3 directionToPlayer = playerTransform.position - Enemy.position;

        float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        targetAngle -= 90f;

        float currentAngle = Enemy.rotation.eulerAngles.z;

        angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        float clampedAngleDifference = Mathf.Clamp(angleDifference, -15f, 15f);

        float finalAngle = currentAngle + clampedAngleDifference;

        Quaternion targetRotation = Quaternion.Euler(0, 0, finalAngle);

        Enemy.rotation = Quaternion.Slerp(Enemy.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        if (IsBossEnemy && EnemyBossHealthBar != null)
        {
            EnemyBossHealthBar.UpdateHealthBar(enemyHealth, maxHealth);
        }
        if (Mathf.Abs(angleDifference) <= attackThreshold && DistanceToPlayer <= 90 && ShotDelay <= 0)
        {
            float Chance = Random.Range(1, 100);
            if (Chance <= AttackChance)
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        else
        {
            isAttacking = false;
            ShotDelay -= Time.deltaTime;
            if (ShotDelay <= 0)
            {
                //Debug.Log("Shot Delay inactive");
            }

        }

    }

    public float MissileDamage = 200;
    public float NukeDamage = 600;
    public float MinigunDamage = 80;
    public float HomingMissileDamage = 400;
    public float FlakDamage = 200;
    public float DroneDamage = 50;
    public float LaserDamage = 100;
    /*
    private void ApplyBuff()
    {
        maxHealth *= (1 + buffAmount);
        enemyHealth = maxHealth;
        maxStamina *= (1 + buffAmount);
        enemyStamina = maxStamina;


        MissileDamage *= (1 + buffAmount);
        NukeDamage *= (1 + buffAmount);
        MinigunDamage *= (1 + buffAmount);
        HomingMissileDamage *= (1 + buffAmount);
        FlakDamage *= (1 + buffAmount);
        DroneDamage *= (1 + buffAmount);
        LaserDamage *= (1 + buffAmount);


        Debug.Log("Enemy buff applied! New Max Health: " + maxHealth + ", New Max Stamina: " + maxStamina);
    }
    */

    void DamageDisplay(float Damage)
    {
        if (SettingController.DamageTextEnabled == true)
        {
            var go = Instantiate(TextPrefab, transform.position, Quaternion.identity, transform);
            go.GetComponent<TextMeshPro>().text = Mathf.Round(Damage).ToString();
        }
        else
        {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            float Damage = col.gameObject.GetComponent<PlayerWeaponStats>().Damage;
            string ID = col.gameObject.GetComponent<PlayerWeaponStats>().ID;
            enemyHealth -= Damage;

            HealthReturn = Damage * StatsController.lifeSteal;
            playerController.playerHealth += HealthReturn;

            //Debug.Log("Enemy Damage Taken " + Damage);
            //Debug.Log("Enemy Health " + enemyHealth);
            DamageDisplay(Damage);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            float Damage = col.gameObject.GetComponent<PlayerWeaponStats>().Damage;
            string ID = col.gameObject.GetComponent<PlayerWeaponStats>().ID;
            enemyHealth -= Damage;

            HealthReturn = Damage * StatsController.lifeSteal;
            playerController.playerHealth += HealthReturn;

            //Debug.Log("Enemy Damage Taken " + Damage);
            //Debug.Log("Enemy Health " + enemyHealth);
            DamageDisplay(Damage);
        }
        if (col.gameObject.tag == "Mine")
        {
            float Damage = col.gameObject.GetComponent<MineExplosionController>().Damage;
            string ID = "Mine";
            enemyHealth -= Damage;

            HealthReturn = Damage * StatsController.lifeSteal;
            playerController.playerHealth += HealthReturn;

            //Debug.Log("Enemy Damage Taken " + Damage);
            //Debug.Log("Enemy Health " + enemyHealth);
            DamageDisplay(Damage);
        }
    }
}