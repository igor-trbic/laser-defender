using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int GetDamage() {
        Debug.Log("DAMEG: " + damage);
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }

    // public void IncreaseDamage(int toIncrease) {
    //     Debug.Log("INCREASE DMG: " +toIncrease);
    //     damage += toIncrease;
    // }

    // public void DecreaseDamage(int toDecrese) {
    //     damage -= toDecrese;
    // }

    public void SetDamage(int damageToSet) {
        damage = damageToSet;
    }
}