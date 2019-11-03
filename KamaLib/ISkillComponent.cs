using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    public interface ISkillComponent
    {
        Action OnSpChanged { get; set; }
        float MaxSp { get; }
        float Sp { get; }

        void SpendSp(float amount);
        void IncreaseSp(float amount);

        void Initializer(float maxSp, float sp);
    }
}
