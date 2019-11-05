using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KamaLib
{
    public interface ILevelComponent
    {
        int CurrentLevel { get; }
        int maxLevel { get; }
        //int CurrentATK { get; }
        //int CurrentDEF { get; }
        //int CurrentEXP { get; }
        //int maxEXP { get; }
        bool isMaxLevel { get; }
        //void InitializeLevel(int level, int maxlevel);
        //void InitializeATK(int atk);
        //void InitializeDEF(int def);
        //void InitializeEXP(int exp, int maxexp);
        //void Initialize(int setlevel, int setmaxlevel, int setatk, int setdef, int setexp, int setmaxexp, float hp, float maxhp, float sp, float maxsp);
        void Initialize(int level, int maxlevel);
        void LevelUp();
        //void UpdateEXP(int exp);
        //void UpdateATK(int atk);
        //void UpdateDEF(int def);
    }
}
