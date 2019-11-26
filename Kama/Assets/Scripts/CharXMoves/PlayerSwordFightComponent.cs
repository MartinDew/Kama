using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;
using System;

[Serializable]
public class PlayerSwordFightComponent : MonoBehaviour, IAttackComponent
{
    public float BaseDamage = 10;
    public float AttackRange = 10;
    public float AttackSpeed = 1;
    public IWeaponComponent SwordComponent;

    private SwordFightingComponent swordFight;
    public IEnumerable<Func<float>> Attacks => swordFight.Attacks;
    public float baseDamage => swordFight.baseDamage;
    public float attackSpeed => swordFight.attackSpeed;
    public float attackRange => swordFight.attackRange;
    public IWeaponComponent weaponComponent => swordFight.weaponComponent;
    public float Attack() => swordFight.Attack();
    public float getTotalRange() => swordFight.getTotalRange();
    public float getTotalSpeed() => swordFight.getTotalSpeed();
    private void Awake()
    {
        if ((SwordComponent = GetComponentInChildren<IWeaponComponent>()) == null)
        {
            SwordComponent = NoWeapon();
        }
        swordFight = new SwordFightingComponent(BaseDamage, AttackRange, AttackSpeed, SwordComponent);
    }

    private Sword NoWeapon() => new Sword(0, 0, 0, 0, 0, "Vide");
    
    // Permet d'équipper une nouvelle arme.
    public void equipWeapon(IWeaponComponent weapon)
    {
        if (weapon == null)
            weapon = NoWeapon();
        swordFight.changeWeapon(weapon);
        Debug.Log($"New weapon equipped {weaponComponent.name}");
    }

    // Permet d'équipper aucune arme
    public void equipNoWeapon()
    { 
        swordFight.changeWeapon(NoWeapon());
        Debug.Log($"New weapon equipped {weaponComponent.name}");
    }
}