using UnityEngine;
using KamaLib;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
    public LevelClass levelClass;
    private int defaultLevel = 1;
    public int CurrentLevel => levelClass.CurrentLevel;
    //public int CurrentATK => levelClass.CurrentATK;
    //public int CurrentDEF => levelClass.CurrentDEF;
    //public int CurrentEXP => levelClass.CurrentEXP;
    //public int maxEXP => levelClass.maxEXP;
    public int maxLevel => levelClass.maxLevel;
    public bool isMaxLevel => levelClass.isMaxLevel;
    public void Initialize(int level, int maxlevel) => levelClass = new LevelClass(level, maxlevel);
    public void LevelUp() => levelClass.LevelUp();

    private void Awake() => levelClass = new LevelClass(defaultLevel, maxLevel);

    //public void UpdateATK(int atk) => levelClass.UpdateATK(atk);
    //public void UpdateDEF(int def) => levelClass.UpdateDEF(def);
    //public void UpdateEXP(int exp) => levelClass.UpdateEXP(exp);
    //public void InitializeLevel(int level, int maxlevel) =>  levelClass.InitializeLevel(level, maxlevel);
    //public void InitializeATK(int atk) => levelClass.InitializeATK(atk);
    //public void InitializeDEF(int def) => levelClass.InitializeDEF(def);
    //public void InitializeEXP(int exp, int maxexp) => levelClass.InitializeEXP(exp, maxexp);

    //public void Initialize(int setlevel, int setmaxlevel, int setatk, int setdef, int setexp, int setmaxexp, float hp, float maxhp, float sp, float maxsp)
    //   => levelClass = new LevelClass(setlevel, setmaxlevel, setatk, setdef, setexp, setmaxexp, hp, maxhp, sp, maxsp);
}
