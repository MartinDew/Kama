using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    /// <summary>
    /// Le skill est ce que le personnage utiliserait dans une situations de classes multiples. Ici le skill est de la stamina.
    /// Le skill prend en conte le skillMax, sa quantité, et sa dépense.
    /// </summary>
    public interface ISkillComponent
    {
        Action OnSpChanged { get; set; }
        float MaxSp { get; }
        float Sp { get; }

        void SpendSp(float amount);
        void IncreaseSp(float amount);

        void Initialize(float maxSp, float sp);
    }
}
