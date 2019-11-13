using System;

namespace KamaLib
{
    public interface ILevelComponent
    {
        Action OnExpChanged { get; set; }
        Action OnLevelChanged { get; set; }
        float CurrentLevel { get; }
        float maxLevel { get; }
        bool isMaxLevel { get; }
        float CurrentATK { get; }
        float CurrentEXP { get; }
        float maxEXP { get; }
        float CurrentHP { get; }
        float CurrentSP { get; }
        void Initialize(float level, float maxlevel, float exp, float maxexp, float atk, float hp, float sp);
        void InitializeStats(float hp, float sp, float atk);
        void LevelUp();
        void UpdateEXP(float exp);
        void UpdateATK(float atk);
    }
}
