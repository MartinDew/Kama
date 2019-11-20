using KamaLib;
using System;
using UnityEngine;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
    public LevelClass levelClass;
    public const float defaultLevel = 1;
    public Action OnExpChanged { get => levelClass.OnExpChanged; set => levelClass.OnExpChanged = value; }
    public Action OnLevelChanged { get => levelClass.OnLevelChanged; set => levelClass.OnLevelChanged = value; }
    public float CurrentLevel => levelClass.CurrentLevel;
    public float CurrentATK => levelClass.CurrentATK;
    public float CurrentEXP => levelClass.CurrentEXP;
    public float maxEXP => levelClass.maxEXP;
    public float maxLevel => levelClass.maxLevel;
    public bool isMaxLevel => levelClass.isMaxLevel;
    public float CurrentHP => levelClass.CurrentHP;
    public float CurrentSP => levelClass.CurrentSP;
    public void Initialize(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp) => levelClass = new LevelClass(level, maxlevel, exp, maxexp, atk, hp, sp);
    public void InitializeStats(float hp, float sp, float atk) => levelClass.InitializeStats(hp, sp, atk);
    public void LevelUp() =>  levelClass.LevelUp();
    public void UpdateEXP(float exp) => levelClass.UpdateEXP(exp);
    private void Awake() => levelClass = new LevelClass(defaultLevel, maxLevel, CurrentEXP, maxEXP, CurrentATK, CurrentHP, CurrentSP);
    public void UpdateATK(float atk) => levelClass.UpdateATK(atk);
    public void Initialize(float level, float maxlevel)
    {
        throw new NotImplementedException();
    }
}
