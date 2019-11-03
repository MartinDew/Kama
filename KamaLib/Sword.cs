using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    [Serializable]
    public class Sword : IWeaponComponent
    {
        public string name { get; private set; }
        public float additionalDamage { get; private set; }

        public float attackSpeedAmplificator { get; private set; }

        public float attackRangeAmplificator { get; private set; }
        /// <summary>
        /// Coût en SP
        /// </summary>
        public float cost { get; private set; }
        /// <summary>
        /// Prix
        /// </summary>
        public float price { get; private set; }

        public Sword (float AdditionalDamage, float AttackSpeedAmp, float AttackRangeAmp, float Price, float Cost, string Name)
        {
            name = Name;
            additionalDamage = AdditionalDamage;
            attackSpeedAmplificator = AttackSpeedAmp;
            attackRangeAmplificator = AttackRangeAmp;
            cost = Cost;
            price = Price;
        }
    }
}
