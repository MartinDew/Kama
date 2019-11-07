using System;

namespace KamaLib
{
    [Serializable]
    public class LevelClass : ILevelComponent
    {
        public const int defaultLevel = 1;
        public const int defaultExp = 100;
        public Action OnExpChanged { get; set; }
        public Action OnLevelChanged { get; set; }
        public int CurrentLevel { get; private set; }
        public int maxLevel { get; private set; }
        public bool isMaxLevel { get; private set; }
        public float CurrentATK { get; private set; }
        public int CurrentEXP { get; private set; }
        public int maxEXP { get; private set; }
        public float CurrentHP { get; private set; }
        public float CurrentSP { get; private set; }

        public const int nextEXP = 100;
        public const int enemyEXP = 20;
        
        public LevelClass(int level, int maxlevel, int exp, int maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
            CurrentEXP = exp;
            maxEXP = maxexp;
            CurrentATK = atk;
            CurrentHP = hp;
            CurrentSP = sp;
        }

        public void Initialize(int level, int maxlevel, int exp, int maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
            CurrentEXP = exp;
            maxEXP = maxexp;
            CurrentATK = atk;
            CurrentHP = hp;
            CurrentSP = sp;
        }

        public void InitializeStats(float hp, float sp)
        {
            CurrentHP = hp;
            CurrentSP = sp;
            CurrentLevel = defaultLevel;
            CurrentEXP = defaultExp;
        }

        public void LevelUp()
        {
            CurrentLevel++;
            CurrentEXP = 0;
            CurrentHP += 10;
            CurrentSP += 5;
            UpdateATK(2);
            OnLevelChanged();
            if (CurrentLevel == maxLevel)
                isMaxLevel = true;
        }

        public void UpdateEXP(int exp)
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
        }
        public void UpdateATK(float atk) => CurrentATK += atk;
    }
}
