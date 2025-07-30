
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [Header("References")]
    [SerializeField] string Scene = "GameOverPc";
    [SerializeField] CameraShake CameraShake;
    [SerializeField] Animator anim;
    [SerializeField] Weapons Weapons;
    [SerializeField] GameMenu GameMenu;
    [SerializeField] SkillsController SkillsController;
    [SerializeField] StatDisplay StatDisplay;
    [SerializeField] NukeControllerPlayer NukeControllerPlayer;
    [SerializeField] MiniGunControllerPlayer MiniGunControllerPlayer;
    [SerializeField] MissleControllerPlayer MissleControllerPlayer;
    [SerializeField] HomingMissleControllerPlayer HomingMissleControllerPlayer;
    [SerializeField] FlakControllerPlayer FlakControllerPlayer;
    [SerializeField] DroneControllerPlayer DroneControllerPlayer;
    [SerializeField] LevelsManager LevelsManager;
    [SerializeField] StatsController StatsController;
    [SerializeField] SettingController SettingController;
    [SerializeField] RandomEnemySpawn RandomEnemySpawn;
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider StaminaSlider;
    [SerializeField] Slider StaminaSlider2;
    [SerializeField] GameObject PoisonEffect;
    [SerializeField] GameSettings GameSettings;
    [SerializeField] GameObject StarParticle;
    ValueSave ValueSave;

    [Space (10)]
    [Header("Settings")]
    public float playerStamina = 100;
    public float maxStamina = 100;
    public float playerHealth = 100;
    public float maxHealth = 100;
    public bool canReload = false;
    public bool RealisticMovement = false;
    [SerializeField] public float moveSpeed = 20;
    [SerializeField] public bool Dead = false;
    float inputHorizontal;
    float inputVertical;
    int minutes;
    float buffAmount;
    int timeInterval = 10;
    float percentIncrease = 0.1f;
    float Bonus = 1;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ValueSave = GameObject.FindGameObjectWithTag("Value").GetComponent<ValueSave>();
        RealisticMovement = DifficultyGameData.RealisticMovement;

    }

    void Update()
    {
        bool Animations = (PlayerPrefs.GetInt("AnimationsActive") != 0);
        anim.enabled = Animations;
        playerHealth = StatsController.CurrentHealth;
        maxHealth = StatsController.MaxHealth;
        playerStamina = StatsController.CurrentStamina;
        maxStamina = StatsController.MaxStamina;
        moveSpeed = StatsController.ShipSpeed;
        rb.mass = StatsController.ShipMass;
        rb.linearDamping= StatsController.ShipDamping;
        minutes = RandomEnemySpawn.minutes;
        

        if (StatsController.CurrentHealth <= 0)
        {
            //Debug.Log("Player Has < 0 hp");
            if (StatsController.ExtraLives >= 1)
            {
                StatsController.CurrentHealth = StatsController.MaxHealth;
                StatsController.ExtraLives--;
                //Debug.Log("Player Has Healed " + StatsController.CurrentHealth + "/"+ StatsController.MaxHealth);
                //Debug.Log("Player Has " + StatsController.ExtraLives + " Extra lives left");
                return;
            }
            ValueSave.Save();
            SceneManager.LoadScene(Scene);
            //Debug.Log("Player Has Died");

        }
        if (StatsController.CurrentHealth > StatsController.MaxHealth)
        {
            StatsController.CurrentHealth = StatsController.MaxHealth;
        }
        if (StatsController.Missile == true)
        {
            Weapons.MissileUnlocked();
        }
        if (StatsController.Nuke == true)
        {
            Weapons.NukeUnlocked();
        }

        if (StatsController.Minigun == true)
        {
            Weapons.MiniGunUnlocked();
        }
        if (StatsController.HomingMissile == true)
        {
            Weapons.HomingMissileUnlocked();
        }

        if (StatsController.Flak == true)
        {
            Weapons.FlakUnlocked();
        }

        if (StatsController.Drone == true)
        {
            Weapons.DroneUnlocked();
        }
        if (StatsController.Laser == true)
        {
            Weapons.LaserUnlocked();
        }
        if (StatsController.MineHeavy == true)
        {
            Weapons.MineHeavyUnlocked();
        }
        if (StatsController.MineRapid == true)
        {
            Weapons.MineRapidUnlocked();
        }
        if (StatsController.MineHoming == true)
        {
            Weapons.MineHomingUnlocked();
        }
        if (minutes > timeInterval)
        {
            percentIncrease += 0.1f;
            if (minutes >= 40)
            {
                percentIncrease += 0.05f;
            }
            timeInterval += 10;
        }
        buffAmount = percentIncrease * minutes;

    }
    void FixedUpdate()
    {
        if (!RealisticMovement)
        {
            inputHorizontal = Input.GetAxis("Horizontal");
            inputVertical = Input.GetAxis("Vertical");

            if (inputHorizontal != 0 || inputVertical != 0)
            {
                rb.AddForce(new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed));
            }
        }
        else
        {
            rb.AddForce(transform.up *  Input.GetAxis("SpaceMovement") * moveSpeed);
        }


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

    }
    public Vector2 GetPlayerVelocity()
    {
        return rb.linearVelocity;
    }
    public Vector2 GetPlayerForwardVelocity()
    {
        Vector2 Velocity = rb.linearVelocity;
        Vector3 ForwardDirection = transform.up;
        float speedInFacingDirection = Vector2.Dot(Velocity, ForwardDirection);
        Vector2 forwardVelocity = ForwardDirection * speedInFacingDirection;
        if (CheckIfReletiveDirection(forwardVelocity))
            return Vector2.zero;
        else
            return forwardVelocity;
    }
    bool CheckIfReletiveDirection(Vector2 Direction)
    {
        Direction.Normalize();
        Vector2 NegativePlayerDirection = -transform.up;
        NegativePlayerDirection.Normalize();

        float dot = Vector2.Dot(NegativePlayerDirection, Direction);

        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        return angle <= 15;
    }
    public void SkillsAfterLevelUp()
    {
        StatsController.CurrentHealth = StatsController.MaxHealth;
        StatsController.CurrentStamina = StatsController.MaxStamina;
    }

    private async void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            CameraShake.Shake(0.3f, 0.1f);
            float Damage = col.gameObject.GetComponent<EnemyWeaponStats>().Damage;
            string ID = col.gameObject.GetComponent<EnemyWeaponStats>().ID;
            StatsController.CurrentHealth -= Damage;
        }
        if (col.gameObject.tag == "ExperincePoint")
        {
            col.gameObject.transform.DOMove(this.transform.position, 0.1f, false);
            await Task.Delay(100);
            StatsController.currentXP += col.GetComponent<ExperincePointStat>().Experince;
            var Particle = Instantiate(StarParticle, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy Mine")
        {
            float Damage = col.gameObject.GetComponent<MineExplosionController>().Damage;
            StatsController.CurrentHealth -= Damage;
        }
    }
}
