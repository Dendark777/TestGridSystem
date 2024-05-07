using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    [Serializable]
    public enum TileType
    {
        None,
        Norm,
        WallUp,
        WallDown,
        WallLeft,
        WallRight,
        WallUpRight,
        WallUpLeft,
        WallDownRight,
        WallDownLeft,
    }
}
