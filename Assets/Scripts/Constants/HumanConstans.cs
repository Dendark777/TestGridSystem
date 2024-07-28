using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Constants
{
    public static class HumanConstans
    {
        public static int MaxBigCountItem { get; private set; } = 2;
        public static int MinCountItem { get; private set; } = 4;
        public static int MaxHealth { get; private set; } = 4;
        public static int CountMaxActions { get; private set; } = 2;
        public static int CountCellPerAction { get; private set; } = 2;
        public static string AnimatorPath { get; private set; } = "Animators/Humans/HumanAnimatorController";
    }
}
