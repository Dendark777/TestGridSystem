using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Constants
{
    public static class ZombieConstans
    {
        public static int MaxBigCountItem { get; private set; } = 0;
        public static int MinCountItem { get; private set; } = 0;
        public static int MaxHealth { get; private set; } = 1;
        public static int CountMaxActions { get; private set; } = 2;
        public static int CountCellPerAction { get; private set; } = 1;
        public static string AnimatorPath { get; private set; } = "Animators/Zombie/ZombieAnimatorController";
        public static string LogoPath { get; private set; } = "Sprites/Zombie/Logo";
        public static int MaxCountZombie => PlayerConstants.CountAllChip * 3;

    }
}
