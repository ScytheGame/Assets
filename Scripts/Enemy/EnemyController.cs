
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyAI EnemyAi;
    [SerializeField] GameObject TextPrefab;
    [SerializeField] GameObject PoisonEffect;
    [SerializeField] Slider HealthSlider;
    [SerializeField] GameSettings GameSettings;
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
    public float AttackChance = 40;
    public float EnemyAttackRateMultiplyer = 1;
    public bool IsBossEnemy = false;
    float expTimeBuff = 0;
    float poisondamagelength = 1f;
    bool ApplyOnce;



    void Start()
    {
        AttackChance = PlayerPrefs.GetFloat("EnemyAttackChance", 40);
        EnemyAttackRateMultiplyer = PlayerPrefs.GetFloat("EnemyAttackRateMultiplyer", 1);

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
            Debug.LogError("Player GameObject not found! Make sure the Player is tagged as 'Player'.");
        }
        if (level != null)
        {
            LevelsManager = level.GetComponent<LevelsManager>();
            if (LevelsManager == null)
            {
                Debug.LogError("LevelsManager component not found on the UI GameObject!");
            }
            GameSettings = level.GetComponent<GameSettings>();
            if (GameSettings == null)
            {
                Debug.LogError("GameSettings component not found on the UI GameObject!");
            }
        }
        if (EnemyGenerator != null)
        {
            RandomEnemySpawn = EnemyGenerator.GetComponent<RandomEnemySpawn>();

            if (RandomEnemySpawn == null)
            {
                Debug.Log("RandomEnemySpawn Component not found on the EnemyGenerator gameobject");
            }
        }
        if (Stats != null)
        {
            StatDisplay = Stats.GetComponent<StatDisplay>();
            if (StatDisplay == null)
            {
                Debug.Log("couldn't find statDisplay on gameobject Stats");
            }
        }
        GameTime = RandomEnemySpawn.gameTime;
        minutes = RandomEnemySpawn.minutes;
        Level = Random.Range(StatsController.currentLevel - 5, StatsController.currentLevel + 5);



        if (Level >= 0)
        {
            for (int i = 0; i < Level; i++)
            {
                int random = Random.Range(0, 2);

                if (random == 0)
                {
                    maxHealth /= 0.9f;
                    enemyHealth = maxHealth;
                }
                if (random == 1)
                {
                    maxStamina /= 0.9f;
                    enemyStamina = maxStamina;

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
                }
            }
        }
        else if (Level < 0)
        {
            for (int i = 0; i > Level; i--)
            {
                int random = Random.Range(1, 3);

                if (random == 0)
                {
                    maxHealth *= 0.9f;
                    enemyHealth = maxHealth;
                }
                if (random == 1)
                {
                    maxStamina *= 0.9f;
                    enemyStamina = maxStamina;
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
                }
                if (random == 3)
                {
                    EnemyAttackRateMultiplyer += 0.1f;
                }
            }
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
                Experince.GetComponent<ExperincePointStat>().Experince = Random.Range(StatsController.ExpGain, StatsController.ExpGain * 2);
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
            Debug.LogWarning("Player or Enemy transform is not assigned!");
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

        if (Mathf.Abs(angleDifference) <= attackThreshold && DistanceToPlayer <= 250 && ShotDelay <= 0)
        {
            float Chance = Random.Range(1, 100);
            if (Chance <= AttackChance)
            {
                isAttacking = true;
            }
            else
            {
                ShotDelay = 1;
                isAttacking = false;
                Debug.Log("Shot Delay active");
            }
        }
        else
        {
            isAttacking = false;
            ShotDelay -= Time.deltaTime;
            if (ShotDelay <= 0)
            {
                Debug.Log("Shot Delay inactive");
            }

        }


        if (ApplyOnce == false)
        {
            if (IsBossEnemy == true && GameSettings.EnemyHealthFloat >= 1)
            {
                maxHealth = GameSettings.EnemyHealthFloat * 5;
            }
            else if (GameSettings.EnemyHealthFloat >= 1)
            {
                maxHealth = GameSettings.EnemyHealthFloat;
            }
            
            // ApplyBuff();
            ApplyOnce = true;

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
            go.GetComponent<TextMeshPro>().text = Damage.ToString();
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

            HealthReturn = Damage * StatsController.lifesteal;
            playerController.playerHealth += HealthReturn;

            Debug.Log("Enemy Damage Taken " + Damage);
            Debug.Log("Enemy Health " + enemyHealth);
            DamageDisplay(Damage);
            StartCoroutine(poisondamage(ID));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            float Damage = col.gameObject.GetComponent<PlayerWeaponStats>().Damage;
            string ID = col.gameObject.GetComponent<PlayerWeaponStats>().ID;
            enemyHealth -= Damage;

            HealthReturn = Damage * StatsController.lifesteal;
            playerController.playerHealth += HealthReturn;

            Debug.Log("Enemy Damage Taken " + Damage);
            Debug.Log("Enemy Health " + enemyHealth);
            DamageDisplay(Damage);
            StartCoroutine(poisondamage(ID));
        }
    }

    IEnumerator poisondamage(string weapon)
    {
        if (weapon == "Missile" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootMissile);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "Nuke" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootNuke);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "Minigun" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootMiniGun);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "HomingMissile" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootHoming);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "Flak" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootFlak);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "Drone" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootDrone);
                yield return new WaitForSeconds(1);
            }
        }
        if (weapon == "Laser" && StatsController.poisonShoot == true)
        {
            for (int i = 0; i < 5; i++)
            {
                ApplyPoisonDamage(StatsController.poisonShootLaser);
                yield return new WaitForSeconds(1);
            }
        }
    }

    void ApplyPoisonDamage(float damage)
    {
        enemyHealth -= damage;
        DamageDisplay(damage);
        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-360, 360));
        Instantiate(PoisonEffect, transform.position, transform.rotation, transform);
    }
}