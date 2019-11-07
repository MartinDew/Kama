using System;

namespace KamaLib
{
    public interface ILevelComponent
    {
        Action OnExpChanged { get; set; }
        Action OnLevelChanged { get; set; }
        int CurrentLevel { get; }
        int maxLevel { get; }
        bool isMaxLevel { get; }
        float CurrentATK { get; }
        int CurrentEXP { get; }
        int maxEXP { get; }
        float CurrentHP { get; }
        float CurrentSP { get; }
        void Initialize(int level, int maxlevel, int exp, int maxexp, float atk, float hp, float sp);
        void InitializeStats(float hp, float sp);
        void LevelUp();
        void UpdateEXP(int exp);
        void UpdateATK(float atk);
    }
}
