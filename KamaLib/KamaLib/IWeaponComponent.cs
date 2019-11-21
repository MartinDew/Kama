using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    /// <summary>
    /// Le IWeapon component est une interface afin de garder une possibilité de modularité pour les armes.
    /// Les armes prennent un nom, et des multiplicateurs.
    /// </summary>
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
