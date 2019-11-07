using KamaLib;
using System;
using UnityEngine;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
    public LevelClass levelClass;
    public const int defaultLevel = 1;
    public Action OnExpChanged { get => levelClass.OnExpChanged; set => levelClass.OnExpChanged = value; }
    public Action OnLevelChanged { get => levelClass.OnLevelChanged; set => levelClass.OnLevelChanged = value; }
    public int CurrentLevel => levelClass.CurrentLevel;
    public float CurrentATK => levelClass.CurrentATK;
    public int CurrentEXP => levelClass.CurrentEXP;
    public int maxEXP => levelClass.maxEXP;
    public int maxLevel => levelClass.maxLevel;
    public bool isMaxLevel => levelClass.isMaxLevel;
    public float CurrentHP => levelClass.CurrentHP;
    public float CurrentSP => levelClass.CurrentSP;
    public void Initialize(int level, int maxlevel, int exp, int maxexp, float atk, float hp, float sp) => levelClass = new LevelClass(level, maxlevel, exp, maxexp, atk, hp, sp);
    public void InitializeStats(float hp, float sp) => levelClass.InitializeStats(hp, sp);
    public void LevelUp() =>  levelClass.LevelUp();
    public void UpdateEXP(int exp) => levelClass.UpdateEXP(exp);
    private void Awake() => levelClass = new LevelClass(defaultLevel, maxLevel, CurrentEXP, maxEXP, CurrentATK, CurrentHP, CurrentSP);
    public void UpdateATK(float atk) => levelClass.UpdateATK(atk);

    public void Initialize(int level, int maxlevel)
    {
        throw new NotImplementedException();
    }
}
