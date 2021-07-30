using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    
    [Header("Shooting")]
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 3f;

    [SerializeField] float projectileSpeed = -7f;
    [SerializeField] GameObject laserBeam;

    [Header("Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float exposionDuration;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathSFXVolume = 0.7f;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0,1)] float shootingSFXVolume = 0.25f;

    [Header("Power Ups")]
    [SerializeField] GameObject healthUp;
    [Range(0, 100)][SerializeField] float chanceToSpawnHealth = 50f;
    float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        }
    }

    private void Fire() {
        GameObject myLaser = Instantiate(laserBeam,
                                         transform.position,
                                         Quaternion.identity) as GameObject;
        myLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(shootingSound, Camera.main.transform.position, shootingSFXVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0) {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy() {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        SpawnPowerUp();
        Destroy(gameObject);
        GameObject explosion = Instantiate(
            deathVFX,
            transform.position,
            transform.rotation
        );
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        Destroy(explosion, exposionDuration);
    }

    private void SpawnPowerUp() {
        if (Random.Range(0f, 100f) <= chanceToSpawnHealth) {
            GameObject myPowerUp = Instantiate(
                healthUp,
                transform.position,
                Quaternion.identity
            ) as GameObject;
        }
    }
}
