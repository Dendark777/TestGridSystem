using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class Constants
    {
        public static int MapSizeX { get; private set; } = 24;
        public static int MapSizeY { get; private set; } = 20;
        public static float MoveSpeed { get; private set; } = 5f;
        public static int MaxBigCountItem { get; private set; } = 2;
        public static int MinCountItem { get; private set; } = 4;
        public static int OrderCallFuntion { get; set; } = 1;    

        public static int OrderFuntion()
        {
            return OrderCallFuntion++;
        }
    }
}
