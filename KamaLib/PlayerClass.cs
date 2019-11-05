using System;
using System.Collections.Generic;
using System.Text;

namespace KamaLib
{
    [Serializable]
    public class PlayerClass
    {
        public IHealthComponent HealthComponent { get; set; }
        public IAttackComponent AttackComponent { get; set; }
        public ISkillComponent SkillComponent { get; set; }
        public ILevelComponent
    }
}
