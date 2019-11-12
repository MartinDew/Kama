using System;

namespace KamaLib
{
    [Serializable]
    public class LevelClass : ILevelComponent
    {
        public const float defaultLevel = 1;
        public const float defaultExp = 0;
        public const float defaultMaxExp = 100;
        public Action OnExpChanged { get; set; }
        public Action OnLevelChanged { get; set; }
        public float CurrentLevel { get; private set; }
        public float maxLevel { get; private set; }
        public bool isMaxLevel { get; private set; }
        public float CurrentATK { get; private set; }
        public float CurrentEXP { get; private set; }
        public float maxEXP { get; private set; }
        public float CurrentHP { get; private set; }
        public float CurrentSP { get; private set; }

        public const float nextEXP = 100;
        public const float enemyEXP = 20;
        
        public LevelClass(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
            CurrentEXP = exp;
            maxEXP = maxexp;
            CurrentATK = atk;
            CurrentHP = hp;
            CurrentSP = sp;
        }

        public void Initialize(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            maxLevel = maxlevel;
            CurrentEXP = exp;
            maxEXP = maxexp;
            CurrentATK = atk;
            CurrentHP = hp;
            CurrentSP = sp;
        }

        public void InitializeStats(float hp, float sp, float atk)
        {
            CurrentHP = hp;
            CurrentSP = sp;
            CurrentATK = atk;
            CurrentLevel = defaultLevel;
            CurrentEXP = defaultExp;
            maxEXP = defaultMaxExp;
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

        public void UpdateEXP(float exp)
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
