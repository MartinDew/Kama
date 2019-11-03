using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    public interface IWeaponComponent
    {
        string name { get; }
        float additionalDamage { get; }
        float attackSpeedAmplificator { get; }
        float attackRangeAmplificator { get; }
        /// <summary>
        /// La consommation en munition, stamina, ou mana
        /// </summary>
        float cost { get;}
        /// <summary>
        /// Prix de l'arme
        /// </summary>
        float price { get; }

    }
}
