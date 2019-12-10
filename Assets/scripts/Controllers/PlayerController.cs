using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip MusicClip;
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private float Speed;
    [SerializeField] private float RotationAngle = 30f;
    [SerializeField] public int MaxHealth = 100;
    private int currHealth;
    private Rigidbody Rb;
    private BoxCollider PlayerBoundary;
    private HealthBarController health;
    private GameController gameController;

    //Macros for difficulty: 20, 25 or 35 damage
    //Ship with max health of 100 can take 5, 4 or 3 hits before exploding

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        Rb = GetComponent<Rigidbody>();
        MusicSource.clip = MusicClip;
        MusicSource.volume = 0.5f;
        PlayerBoundary = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        currHealth = MaxHealth;
        this.HealthBar.TryGetComponent<HealthBarController>(out this.health);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rb.MoveRotation(Quaternion.Euler(new Vector3(90, 0, -1 * RotationAngle * moveHorizontal)));
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rb.AddForce(movement * Speed, ForceMode.Impulse);
        CheckPlayerBoundary();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoundary")
        {
            Rb.velocity = Vector3.zero;
            //Debug.Log(Time.deltaTime);
        }
        else if (other.tag == "Enemy")
        {
            currHealth -= 25;                   //TODO change this to Macro when difficulty is added
            health.TakeDamage(25, MaxHealth);   //TODO same as above
            CameraShake.changeShakeDuration(1);
            if (currHealth <= 0)
            {
                MusicSource.Play();
                MusicSource.volume = 1f;
                Destroy(Instantiate(playerExplosion, transform.position, transform.rotation), 2);
                Destroy(gameObject);
<<<<<<< HEAD
                gameController.AddScore((int)MultiShooter.timer);
                SceneManager.LoadScene("End");
=======
                Initiate.Fade("End", Color.black, 0.3f);

>>>>>>> 87288519d2ec022befbaf2387897c237b294cc6a
            }
            MusicSource.Play();
            Destroy(Instantiate(explosion, other.transform.position, other.transform.rotation), 2);
            Destroy(other.gameObject);
        }
    }

    private void CheckPlayerBoundary()
    {
        var boundaryX = PlayerBoundary.size.x / 2;
        var boundaryZ = PlayerBoundary.size.z / 2;
        var zOffset = 30f;
        var x = Rb.position.x;
        var y = Rb.position.y;
        var z = Rb.position.z;

        if (Mathf.Abs(x) > boundaryX)
        {
            x = ((x < 0) ? -1 : 1) * boundaryX;
        }
        if (z > boundaryZ + zOffset || z < zOffset - boundaryZ)
        {
            z = ((z < zOffset) ? -1 : 1) * boundaryZ + zOffset;
        }

        Rb.position = new Vector3(x, y, z);
    }
}
