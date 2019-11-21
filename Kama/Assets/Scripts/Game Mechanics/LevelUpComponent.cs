using System.Collections;
using System.Collections.Generic;
using KamaLib;
using System;
using UnityEngine;

public class LevelUpComponent : MonoBehaviour, ILevelComponent
{
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

    public void Initialize(float level, float maxlevel, float exp, float maxExp, float atk, float hp, float sp) => levelClass = new LevelClass(level, maxlevel, exp, maxExp, atk, hp, sp);
    public void InitializeStats(float hp, float sp, float atk) => levelClass = new LevelClass(hp, sp, atk);
    public void LevelUp() =>  levelClass.LevelUp();
    public void UpdateEXP(float exp) => levelClass.UpdateEXP(exp);
    /// <summary>
    /// Lors du awake ou du start, qu'on utilise ici car on veut que tout le reste soit initialisé,
    /// Tu es supposé initialiser ton levelClass, donc appeler le constructeur. Ce que tu faisais, c'était d'appeler un constructeur 
    /// puis ensuite tu rechangeait toute les variables sans rappeler le constructeur et ce dans le player component. Ce que tu aurait du faire 
    /// c'est ce qui suit. Déclare toi un autre constructeur qui appel initializeStats dans ta classe puis passe les variables en paramètres.
    /// En résumé, le problème était bien ton code.
    /// </summary>
    private void Start() => levelClass = new LevelClass(GetComponent<IHealthComponent>().MaxHP, GetComponent<ISkillComponent>().MaxSp, GetComponent<IAttackComponent>().baseDamage); //Simple
    public void UpdateATK(float atk) => levelClass.UpdateATK(atk);
    public void Initialize(float level, float maxlevel)
    {
        throw new NotImplementedException();
    }
}
