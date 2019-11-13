using System;
using KamaLib;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public float HP;
    public float MaxHP;
    public float SP;
    public float MaxSP;

    public float currentLevel;
    public float maxLevel;
    public float currentEXP;
    public float maxEXP;
    public float currentATK;

    public int potionCount;
    public int[] itemIds;

    public PlayerData(PlayerComponent player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        HP = player.HealthComponent.HP;
        MaxHP = player.HealthComponent.MaxHP;
        SP = player.SkillComponent.Sp;
        MaxSP = player.SkillComponent.MaxSp;

        currentLevel = player.LevelComponent.CurrentLevel;
        maxLevel = player.LevelComponent.maxLevel;
        currentEXP = player.LevelComponent.CurrentEXP;
        maxEXP = player.LevelComponent.maxEXP;
        currentATK = player.LevelComponent.CurrentATK;

        int inventorySize = 0;
        potionCount = 0;
        itemIds = new int[Inventory.instance.items.Count];
        foreach (Item item in Inventory.instance.items)
        {
            if (item.id == 2)
                potionCount++;

            itemIds[inventorySize] = item.id;
            inventorySize++;
        }
    }
}
