using UnityEngine;
using KamaLib;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public float HP;
    public float MaxHP;
    public float SP;
    public float MaxSP;

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
        
    }
}
