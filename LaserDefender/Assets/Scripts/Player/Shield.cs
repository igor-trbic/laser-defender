using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField] int numOfSheildHitsBeforeBreak = 3;

    int hitTimes = 0;

    private void OnTriggerEnter2D(Collider2D collider) {
        bool isDamageDealer = collider.GetComponent<DamageDealer>() != null;
        if (isDamageDealer) {
            Destroy(collider.gameObject);
            hitTimes++;
            if (hitTimes >= numOfSheildHitsBeforeBreak) {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetHitTimes() {
        hitTimes = 0;
    }
}
