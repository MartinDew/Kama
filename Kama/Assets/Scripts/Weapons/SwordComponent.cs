using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;

public class SwordComponent : MonoBehaviour, IWeaponComponent
{
    public string Name = "Practice Sword";
    public float AdditionalDamage = 1;
    public float AttackSpeedAmp = 0;
    public float AttackRangeAmp = 0;
    public float Cost = 1;
    public float Price = 5;

    public Sword sword;

    public string name => sword.name;
    public float additionalDamage => sword.additionalDamage;

    public float attackSpeedAmplificator => sword.attackSpeedAmplificator;

    public float attackRangeAmplificator => sword.attackRangeAmplificator;

    public float cost => sword.cost;

    public float price => sword.price;

    private void Awake()
    {
        sword = new Sword(AdditionalDamage, AttackSpeedAmp, AttackRangeAmp, Price, Cost, Name);
    }

}

