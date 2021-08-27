using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    [SerializeField] int damageToAdd = 50;
    [SerializeField] bool isAdditive = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.GetComponent<Player>() != null) {
            if (isAdditive) {
                otherObject.GetComponent<Player>().BuffDamage(damageToAdd);
            } else {
                otherObject.GetComponent<Player>().DebuffDamage(damageToAdd);
            }
        }
        Destroy(gameObject);
    }
}
