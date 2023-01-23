using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    /// <summary>
    /// De la même manière, les stats d'attaque sont représentés par une interface. L'attaque prend en compte quelque données commune simple
    /// Une arme, une attaque de base, un distance, et une vitesse d'attaque, non implémenté.
    /// </summary>
    public interface IAttackComponent
    {
        IEnumerable<Func<float>> Attacks { get; }
        float baseDamage { get; }
        float attackSpeed { get; }
        float attackRange { get; }
        float Attack();
        IWeaponComponent weaponComponent { get; }

        float getTotalRange();
        float getTotalSpeed();

        //void changeWeapon(IWeaponComponent weapon);
    }
}
