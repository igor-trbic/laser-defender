// using System.Numerics;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.1f;
    [SerializeField] int health = 500;
    [Header("Projectile")]
    [SerializeField] GameObject laserBeam;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFireingPeriod = 0.1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathSFXVolume = 0.7f;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0,1)] float shootingSFXVolume = 0.25f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaris();
    }

    // Update is called once per frame
    void Update() {
        Move();
        FireingMyLasers();
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var XPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var YPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        // Debug.Log("xPos = " + XPos + " yPos = " + YPos);
        transform.position = new Vector2(XPos, YPos);
    }

    private void SetUpMoveBoundaris() {
        Camera gameCam = Camera.main;

        // Padding broken a bit
        // TODO: fix it later
        xMin = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;// + padding;
        xMax = gameCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;// - padding;
        yMin = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;// + padding;
        yMax = gameCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;// - padding;
        Debug.Log("xMin: " + xMin + "xMax: " + xMax+ "yMin: " + yMin + "yMax: " + yMax);
    }

    private void FireingMyLasers() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously() {
        while (true) {
            GameObject myLaser = Instantiate(laserBeam,
                                                transform.position,
                                                Quaternion.identity) as GameObject;
            myLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootingSound, Camera.main.transform.position, shootingSFXVolume);
            yield return new WaitForSeconds(projectileFireingPeriod);
        }
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
            DestroyPlayer();
        }
    }

    private void DestroyPlayer() {
        FindObjectOfType<Level>().LoadGameOver();
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        Destroy(gameObject);
    }

    public int GetHealth() {
        return health;
    }
}
