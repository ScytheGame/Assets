using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [Header("References")]
    public string Scene = "GameOverPc";
    public bool Mobile;
    Vector2 turnInput = new Vector2(0, 0);
    InputAction MoveAction;
    InputAction TurnAction;
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
    [SerializeField] public float moveSpeed = 20;
    [SerializeField] public bool Dead = false;
    float inputHorizontal;
    float inputVertical;
    int minutes;
    float buffAmount;
    int timeInterval = 10;
    float percentIncrease = 0.1f;
    float Bonus = 1;
    private void OnEnable()
    {
        MoveAction = InputSystem.actions.FindAction("Move", throwIfNotFound: true);
        TurnAction = InputSystem.actions.FindAction("look", throwIfNotFound: true);
        MoveAction.Enable();
        TurnAction.Enable();
    }
    private void OnDisable()
    {
        MoveAction.Disable();
        TurnAction.Disable();   
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        MoveAction = InputSystem.actions.FindAction("Move", throwIfNotFound: true);
        TurnAction = InputSystem.actions.FindAction("look", throwIfNotFound: true);
        ValueSave = GameObject.FindGameObjectWithTag("Value").GetComponent<ValueSave>();

    }

    void Update()
    {
        bool Animations = (PlayerPrefs.GetInt("AnimationsActive") != 0);
        anim.enabled = Animations;
        playerHealth = StatsController.CurrentHealth;
        maxHealth = StatsController.MaxHealth;
        playerStamina = StatsController.CurrentStamina;
        maxStamina = StatsController.MaxStamina;
        moveSpeed = StatsController.MoveSpeed;
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

        if (!Mobile)
        {
            inputHorizontal = Input.GetAxis("Horizontal");
            inputVertical = Input.GetAxis("Vertical");

            if (inputHorizontal != 0 || inputVertical != 0)
            {
                rb.AddForce(new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed));
            }


            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }
        else
        {

            Vector2 moveInput = MoveAction.ReadValue<Vector2>();
            rb.AddForce(moveInput * moveSpeed);

            if (rb.linearVelocity.sqrMagnitude > 0.01f)
            {
                transform.up = rb.linearVelocity.normalized;
            }

        }
    }

    public void SkillsAfterLevelUp()
    {
        StatsController.CurrentHealth = StatsController.MaxHealth;
        StatsController.CurrentStamina = StatsController.MaxStamina;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            float Damage = col.gameObject.GetComponent<EnemyWeaponStats>().Damage;
            string ID = col.gameObject.GetComponent<EnemyWeaponStats>().ID;
            StatsController.CurrentHealth -= Damage;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ExperincePoint")
        {
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
