using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    public class EnnemyClass
    {
        public IHealthComponent EnnemyHealthComponent { get; set; }
        public IAttackComponent EnnemyAttackComponent { get; set; }
    }
}
