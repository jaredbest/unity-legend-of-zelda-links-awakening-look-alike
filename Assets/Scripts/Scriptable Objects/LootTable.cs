using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot {
    public PowerUp thisLoot;
    public int lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject {
    public Loot[] loot;
    public PowerUp LootPowerUp () {
        int cumProb = 0;
        int currentProb = Random.Range (0, 100);
        for (int i = 0; i < loot.Length; i++) {
            cumProb += loot[i].lootChance;
            if (currentProb <= cumProb) {
                return loot[i].thisLoot;
            }
        }
        return null;
    }
}