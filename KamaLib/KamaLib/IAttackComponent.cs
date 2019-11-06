using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
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
    }
}
