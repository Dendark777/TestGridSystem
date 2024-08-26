using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class LevelConstants
    {
        public static int MapSizeX { get; private set; } = 24;
        public static int MapSizeY { get; private set; } = 20;
        public static float MoveSpeed { get; private set; } = 5f;
        public static int MaxCountChip { get; private set; } = 15;
        public static int MaxCountPlayer { get; private set; } = 8;

    }
}
