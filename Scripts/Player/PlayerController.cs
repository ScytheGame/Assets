
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] string Scene = "GameOverPc";
    [SerializeField] CameraShake CameraShake;
    [SerializeField] StatsController StatsController;
    Rigidbody2D rb;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider StaminaSlider;
    [SerializeField] Slider StaminaSlider2;

    [Header("Settings")]
    public float PlayerStamina { get => StatsController.CurrentAmmo; set => StatsController.CurrentAmmo = value; }
    public float MaxStamina { get => StatsController.MaxAmmo; set => StatsController.MaxAmmo = value; }
    public float PlayerHealth { get => StatsController.CurrentHealth; set => StatsController.CurrentHealth = value; }
    public float MaxHealth { get => StatsController.MaxHealth; set => StatsController.MaxHealth = value; }
    public float MoveSpeed { get => StatsController.ShipSpeed; }

    float InputHorizontal;
    float InputVertical;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateHealthBar();
        UpdateStaminaBar();
        CheckIfDead();
    }
    void FixedUpdate()
    {
        rb.mass = StatsController.ShipMass;
        rb.linearDamping= StatsController.ShipDamping;

        InputHorizontal = Input.GetAxis("Horizontal");
        InputVertical = Input.GetAxis("Vertical");

        if (InputHorizontal != 0 || InputVertical != 0)
        {
            rb.AddForce(new Vector2(InputHorizontal * MoveSpeed, InputVertical * MoveSpeed));
        }
        


        Vector3 MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector2 Direction = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);

        transform.up = Direction;

    }
    public void SkillAfterLevelUp()
    {
        PlayerHealth = MaxHealth;
        PlayerStamina = MaxStamina;
    }
    void UpdateStaminaBar()
    {
        StaminaSlider.value = PlayerStamina;
        StaminaSlider.maxValue = MaxStamina;
        StaminaSlider2.value = PlayerStamina;
        StaminaSlider2.maxValue = MaxStamina;
    }
    void UpdateHealthBar()
    {
        healthSlider.value = PlayerHealth;
        healthSlider.maxValue = MaxHealth;
    }
    public Vector2 GetPlayerVelocity()
    {
        return rb.linearVelocity;
    }

    private void CheckIfDead()
    {
        if (StatsController.CurrentHealth <= 0)
        {
            if (StatsController.ExtraLives >= 1)
            {
                StatsController.CurrentHealth = StatsController.MaxHealth;
                StatsController.ExtraLives--;
                return;
            }
            SceneManager.LoadScene(Scene);

        }

    }

    private async void OnTriggerEnter2D(Collider2D col)
    {
    //    if (col.gameObject.tag == "enemy")
    //    {
    //        CameraShake.Shake(0.3f, 0.1f);
    //        float Damage = col.gameObject.GetComponent<EnemyWeaponStats>().Damage;
    //        string ID = col.gameObject.GetComponent<EnemyWeaponStats>().ID;
    //        StatsController.CurrentHealth -= Damage;
    //    }
    //    if (col.gameObject.tag == "ExperincePoint")
    //    {
    //        await Task.Delay(100);
    //        StatsController.currentXP += col.GetComponent<ExperincePointStat>().Experince;
    //        var Particle = Instantiate(StarParticle, col.gameObject.transform.position, Quaternion.identity);
    //        Destroy(col.gameObject);
    //    }
    //    if (col.gameObject.tag == "Enemy Mine")
    //    {
    //        float Damage = col.gameObject.GetComponent<MineExplosionController>().Damage;
    //        StatsController.CurrentHealth -= Damage;
    //    }
    }
}
