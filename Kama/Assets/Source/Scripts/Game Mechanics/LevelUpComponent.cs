using UnityEngine;
using KamaLib;
using System;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
    public LevelClass levelClass;
    private const int defaultLevel = 1;
    public Action OnExpChanged { get => levelClass.OnExpChanged; set => levelClass.OnExpChanged = value; }
    public Action OnLevelChanged { get => levelClass.OnLevelChanged; set => levelClass.OnLevelChanged = value; }
    public int CurrentLevel => levelClass.CurrentLevel;

    //public int CurrentATK => levelClass.CurrentATK;
    //public int CurrentDEF => levelClass.CurrentDEF;
    public int CurrentEXP => levelClass.CurrentEXP;
    public int maxEXP => levelClass.maxEXP;
    public int maxLevel => levelClass.maxLevel;
    public bool isMaxLevel => levelClass.isMaxLevel;
    public void Initialize(int level, int maxlevel, int exp, int maxexp) => levelClass = new LevelClass(level, maxlevel, exp, maxexp);
    public void LevelUp() =>  levelClass.LevelUp();
    public void UpdateEXP(int exp) => levelClass.UpdateEXP(exp);
    private void Awake() => levelClass = new LevelClass(defaultLevel, maxLevel, CurrentEXP, maxEXP);

    //public void UpdateATK(int atk) => levelClass.UpdateATK(atk);
    //public void UpdateDEF(int def) => levelClass.UpdateDEF(def);
}
