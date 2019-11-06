using UnityEngine;
using KamaLib;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public float HP;
    public float MaxHP;
    public float SP;
    public float MaxSP;
    public int currentLevel;
    public int maxLevel;
    //public int currentATK;
    //public int currentDEF;
    //public int currentEXP;
    //public int maxEXP;

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
    }
}
