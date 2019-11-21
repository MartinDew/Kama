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
        public float MaxLevel { get; private set; }
        public bool IsMaxLevel { get; private set; }
        public float CurrentATK { get; private set; }
        public float CurrentEXP { get; private set; }
        public float MaxEXP { get; private set; }
        public float CurrentHP { get; private set; }
        public float CurrentSP { get; private set; }

        public const float nextEXP = 100;
        public const float enemyEXP = 20;
        
        public LevelClass(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            MaxLevel = maxlevel;
            CurrentEXP = exp;
            MaxEXP = maxexp;
            CurrentATK = atk;
            CurrentHP = hp;
            CurrentSP = sp;
        }
        public LevelClass(float hp, float sp, float atk)
        {
            InitializeStats(hp, sp, atk);
        }
        public void Initialize(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp)
        {
            CurrentLevel = level;
            MaxLevel = maxlevel;
            CurrentEXP = exp;
            MaxEXP = maxexp;
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
            MaxEXP = defaultMaxExp;
        }

        public void LevelUp()
        {
            CurrentLevel++;
            CurrentEXP = 0;
            CurrentHP += 10;
            CurrentSP += 5;
            UpdateATK(2);
            OnLevelChanged();
            if (CurrentLevel == MaxLevel)
                IsMaxLevel = true;
        }

        public void UpdateEXP(float exp)
        {
            if (!IsMaxLevel)
            {
                CurrentEXP += exp;
                if (CurrentEXP >= MaxEXP)
                {
                    LevelUp();
                    MaxEXP += nextEXP;
                }
            }
        }
        public void UpdateATK(float atk) => CurrentATK += atk;
    }
}
