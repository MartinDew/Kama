using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;
using System;

public class BasicEnemyAttackComponent : MonoBehaviour, IAttackComponent
{
    public float BaseDamage = 10;
    public float AttackRange = 10;
    public float AttackSpeed = 1;

    private BasicEnnemyAttack basicAttack;

    public IEnumerable<Func<float>> Attacks => basicAttack.Attacks;

    public float baseDamage => basicAttack.baseDamage;

    public float attackSpeed => basicAttack.attackSpeed;

    public float attackRange => basicAttack.attackRange;

    public IWeaponComponent weaponComponent => null;

    public float Attack() => basicAttack.Attack();

    public float getTotalRange() => basicAttack.getTotalRange();

    public float getTotalSpeed() => basicAttack.getTotalSpeed();

    private void Awake() => basicAttack = new BasicEnnemyAttack(BaseDamage, AttackRange, AttackSpeed);
}
