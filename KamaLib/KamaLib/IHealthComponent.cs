using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    public interface IHealthComponent
    {
        Action OnHpChanged { get; set; }
        float MaxHP { get; }
        float HP { get; }

        void TakeDamage(float damage);
        void Increase(float amount);

        void Initialize(float maxHp, float hp);
    }
}
