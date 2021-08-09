using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    [SerializeField] int damageToAdd = 50;
    [SerializeField] bool isAdditive = true;

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.GetComponent<Player>() != null) {
            if (isAdditive) {
                otherObject.GetComponent<Player>().IncreaseDamage(damageToAdd);
            } else {
                otherObject.GetComponent<Player>().DecreaseDamage(damageToAdd);
            }
        }
        Destroy(gameObject);
    }
}
