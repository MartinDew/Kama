using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KamaLib
{
    [Serializable]
    public class LevelClass : ILevelComponent
    {
        public int CurrentLevel { get; private set; }
        //public int CurrentATK { get; private set; }
        //public int CurrentDEF { get; private set; }
        //public int CurrentEXP { get; private set; }
        //public int maxEXP { get; private set; }
        public int maxLevel { get; private set; }
        public bool isMaxLevel { get; private set; }

        private const int nextEXP = 100;
        //public LevelClass(int setlevel, int setmaxlevel, int setatk, int setdef, int setexp, int setmaxexp, float hp, float maxhp, float sp, float maxsp)
        //   =>  Initialize(setlevel, setmaxlevel, setatk, setdef, setexp, setmaxexp, hp, maxhp, sp, maxsp);
        
        public LevelClass(int level, int maxlevel)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
        }

        

        public void Initialize(int level, int maxlevel)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
        }

        public void LevelUp()
        {
            CurrentLevel++;
            //CurrentEXP = 0;
            if (CurrentLevel == maxLevel)
                isMaxLevel = true;
        }

        //public void InitializeATK(int atk) => CurrentATK = atk;
        //public void InitializeDEF(int def) => CurrentDEF = def;

        //public void InitializeLevel(int level, int maxlevel)
        //{
        //   CurrentLevel = level;
        //    maxLevel = maxlevel;
        //}

        //public void InitializeEXP(int exp, int maxexp)
        //{
        //    CurrentEXP = exp;
        //    maxEXP = maxexp;
        //}

        /*public void Initialize(int setlevel, int setmaxlevel, int setatk, int setdef, int setexp, int setmaxexp, float hp, float maxhp, float sp, float maxsp)
        {
            healthComponent.Initialize(maxhp, hp);
            skillComponent.Initialize(maxsp, sp);
            InitializeLevel(setlevel, setmaxlevel);
            InitializeATK(setatk);
            InitializeDEF(setdef);
            InitializeEXP(setexp, setmaxexp);
        }*/

        /*public void UpdateEXP(int exp)
        {
            if (!isMaxLevel)
            {
                CurrentEXP += exp;
                if (CurrentEXP >= maxEXP)
                {
                    LevelUp();
                    maxEXP += nextEXP;
                }
            }
        }*/

        //public void UpdateATK(int atk) => CurrentATK += atk;

        //public void UpdateDEF(int def) => CurrentDEF += def;
    }
}
