using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] float initialDamage = 100;
    [SerializeField] GameObject laserBeam;
    [SerializeField] float projectileSpeed = 10f;
    // [SerializeField] float projectileFireingPeriod = 0.1f;

    public void Shoot() {
        GameObject myLaser = Instantiate(
                laserBeam,
                transform.position,
                Quaternion.identity
            ) as GameObject;
        myLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        // AudioSource.PlayClipAtPoint(shootingSound, Camera.main.transform.position, shootingSFXVolume);
    }

    public void BuffDamage(int amount) {
        initialDamage += amount;
    }

    public void DebuffDamage(int amount) {
        initialDamage -= amount;
    }
}
