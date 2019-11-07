using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KamaLib
{
    [Serializable]
    public class SwordFightingComponent : IAttackComponent
    {
        public IEnumerable<Func<float>> Attacks { get; }


        public float baseDamage { get; private set; }

        public float attackSpeed { get; private set; }

        public float attackRange { get; private set; } 

        public IWeaponComponent weaponComponent { get; private set; }
        public SwordFightingComponent(float BaseDamage, float AttackRange, float AttackSpeed, IWeaponComponent weapon)
        {
            baseDamage = BaseDamage;
            attackRange = AttackRange;
            attackSpeed = AttackSpeed;
            weaponComponent = weapon;
            Attacks = new Func<float>[]
            {
                () => BaseDamage,
                () => BaseDamage * 2,
            };
        }
        public float Attack() => Attacks.ElementAt(new Random().Next(0, 2)).Invoke() + weaponComponent.additionalDamage;

        public float getTotalRange() => weaponComponent.attackRangeAmplificator + attackRange;

        public float getTotalSpeed() => attackSpeed + weaponComponent.attackSpeedAmplificator;

        public void changeWeapon(IWeaponComponent weapon) => weaponComponent = weapon;
    }
}
