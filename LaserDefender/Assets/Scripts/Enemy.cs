// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 3f;

    [SerializeField] float projectileSpeed = -7f;
    [SerializeField] GameObject laserBeam;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float exposionDuration;


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
        // yield return new WaitForSeconds(projectileFireingPeriod);
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
        if (health < 0) {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy() {
        GameObject explosion = Instantiate(
            deathVFX,
            transform.position,
            transform.rotation
        );
        Destroy(gameObject, exposionDuration);
    }
}
