using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KamaLib
{
    public class BasicEnnemyAttack : IAttackComponent
    {
        public IEnumerable<Func<float>> Attacks { get; }


        public float baseDamage { get; private set; }

        public float attackSpeed { get; private set; }

        public float attackRange { get; private set; }

        public IWeaponComponent weaponComponent { get; }
        public BasicEnnemyAttack(float BaseDamage, float AttackRange, float AttackSpeed)
        {
            baseDamage = BaseDamage;
            attackRange = AttackRange;
            attackSpeed = AttackSpeed;
            Attacks = new Func<float>[]
            {
                () => BaseDamage,
                () => BaseDamage * 0.5f,
                () => BaseDamage * 1.25f,
                () => BaseDamage * 0.75f,
                () => BaseDamage * 1.5f,
            };
        }
        public float Attack() => Attacks.ElementAt(new Random().Next(0, 2)).Invoke();

        public float getTotalRange() => attackRange;

        public float getTotalSpeed() => attackSpeed;
    }
}
