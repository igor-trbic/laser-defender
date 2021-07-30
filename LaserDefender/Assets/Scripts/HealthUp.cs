using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] int healthToAdd;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        // healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collider) {
        player.AddMoreHealth(healthToAdd);
        Destroy(gameObject);
    }
}
