using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] int healthToAdd;

    Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        player.AddMoreHealth(healthToAdd);
        Destroy(gameObject);
    }
}
