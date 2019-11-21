using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    /// <summary>
    /// Le IHealthComponent représente la classe de vie du joueur. On prend une interface et non directement un classe 
    /// afin d'avoir un code modulable. Dans le cas de notre jeu, on n'a qu'une seul composante mais on pourrait ensuite en rajouter.
    /// </summary>
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
