using UnityEngine;

[System.Serializable]
public class Loot {
    public GameObject thisLoot;
    public float lootChance;
}

[CreateAssetMenu(menuName = "Loot Table")]
public class LootTable : ScriptableObject {
    
    public Loot[] loots;

    public GameObject GetLoot() {
        Debug.Log("Getting loot");
        float cumulativeProbabily = 0f;
        float currentProbability = Random.Range(0f, 100f);

        foreach(Loot loot in loots) {
            cumulativeProbabily += loot.lootChance;
            if (currentProbability <= cumulativeProbabily) {
                 return loot.thisLoot;
            }
        }
        return null;
    }
}