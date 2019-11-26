using KamaLib;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
    private GameObject player;
    private LevelClass levelClass;
    public const float defaultLevel = 1;

    public float maxLevel;
    public float maxEXP;
    public float currentXp;

    public Action OnExpChanged { get => levelClass.OnExpChanged; set => levelClass.OnExpChanged = value; }
    public Action OnLevelChanged { get => levelClass.OnLevelChanged; set => levelClass.OnLevelChanged = value; }
    public float CurrentLevel => levelClass.CurrentLevel;
    public float CurrentATK => levelClass.CurrentATK;
    public float CurrentEXP => levelClass.CurrentEXP;
    public float MaxEXP => levelClass.MaxEXP;
    public float MaxLevel => levelClass.MaxLevel;
    public bool IsMaxLevel => levelClass.IsMaxLevel;
    public float CurrentHP => levelClass.CurrentHP;
    public float CurrentSP => levelClass.CurrentSP;
    public void Initialize(float level, float maxlevel, float exp, float maxExp, float atk, float hp, float sp) => 
        levelClass = new LevelClass(level, maxlevel, exp, maxExp, atk, hp, sp);
    public void InitializeStats(float hp, float sp, float atk) => levelClass = new LevelClass(hp, sp, atk);
    public void LevelUp() =>  levelClass.LevelUp();
    public void UpdateEXP(float exp) => levelClass.UpdateEXP(exp);
    public void UpdateATK(float atk) => levelClass.UpdateATK(atk);

    private void Start()
    {
        player = PlayerManager.instance.player;

        levelClass = new LevelClass(GetComponent<IHealthComponent>().MaxHP, GetComponent<ISkillComponent>().MaxSp, GetComponent<IAttackComponent>().baseDamage);
        OnLevelChanged += () =>
        {
            GameObject.Find("Level Value").GetComponent<Text>().text = "Niveau\n" + CurrentLevel;
            GetComponent<IHealthComponent>().Initialize(CurrentHP, CurrentHP);
            GetComponent<ISkillComponent>().Initialize(CurrentSP, CurrentSP);
            GetComponent<AudioSource>().Play();
        };
    }
}
