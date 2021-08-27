using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{

    [SerializeField] int healthToAdd;

    Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        player.ActivateShield();
        Destroy(gameObject);
    }
}
