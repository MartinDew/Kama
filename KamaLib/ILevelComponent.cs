using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KamaLib
{
    public interface ILevelComponent
    {
        int CurrentLevel { get; set; }
        int EXP { get; set; }
        int maxEXP { get; set; }
        bool isMaxLevel { get; set; }
        bool attackPoints { get; set; }
        bool skillPoints { get; set; }

        void Initialize(int setLevel, int maxlevel);
    }
}
