using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodesNormal : GetNeighbourNodes
    {
        public GetNeighbourNodesNormal(GetNeighbourNodes getNeighbourNodes = null) : base(getNeighbourNodes)
        {
        }

        public override bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            try
            {
                var tileType = gridMap.GetTile(currentNode.xPos + x, currentNode.yPos + y).TileTypes[0];
                switch (tileType)
                {
                    case TileType.WallUp:
                        if (y < 0)
                            return true;
                        break;
                    case TileType.WallDown:
                        if (y > 0)
                            return true;
                        break;
                    case TileType.WallLeft:
                        if (x > 0)
                            return true;
                        break;
                    case TileType.WallRight:
                        if (x < 0)
                            return true;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                return true;
            }

            return false;
        }
    }
}
