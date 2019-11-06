using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KamaLib
{
    [Serializable]
    public class StandartHealthClass : IHealthComponent
    {
        public Action OnHpChanged { get; set; }

        public float MaxHP { get; private set; }
        private float hp;
        public float HP
        {
            get { return hp; }
            private set
            {
                if (hp != value)
                {
                    hp = value;
                    if (hp < 0)
                        hp = 0;
                    else if (hp > MaxHP)
                        hp = MaxHP;

                    OnHpChanged?.Invoke();
                }
            }
        }

        public void Increase(float amount) => HP += amount;

        public void TakeDamage(float damage) => HP -= damage;

        public void Initialize(float maxHp, float hp)
        {
            MaxHP = maxHp;
            HP = hp;
        }

        public StandartHealthClass(float maxHp, float hp)
        {
            MaxHP = maxHp;
            HP = hp;
        }
    }
}
