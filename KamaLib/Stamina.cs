using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    [Serializable]
    public class Stamina : ISkillComponent
    {
        public Action OnSpChanged { get ; set ; }
        public float MaxSp { get; private set; }
        private float sp;
        public float Sp
        {
            get { return sp; }
            private set
            {
                if (sp != value)
                {
                    sp = value;
                    if (sp < 0)
                        sp = 0;
                    else if (sp > MaxSp)
                        sp = MaxSp;

                    OnSpChanged?.Invoke();
                }
            }
        }

        public void IncreaseSp(float amount) => Sp += amount;

        public void SpendSp(float amount) => Sp -= amount;

        public void Initialize(float maxSp, float sp)
        {
            MaxSp = maxSp;
            Sp = sp;
        }

        public Stamina (float sp, float maxsp)
        {
            MaxSp = maxsp;
            Sp = sp;            
        }
    }
}
