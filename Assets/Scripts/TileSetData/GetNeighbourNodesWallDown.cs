using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodesWallDown : GetNeighbourNodes
    {
        public GetNeighbourNodesWallDown(GetNeighbourNodes getNeighbourNodes = null) : base(getNeighbourNodes)
        {
        }

        public override bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            if (y == 1)
            {
                var tileTypes = gridMap.GetNode(currentNode.xPos + x, currentNode.yPos + y).TileTypes;
                if (tileTypes.Contains(TileType.WallDown))
                    return true;
            }
            if (y == -1)
            {
                if (x == 0)
                    return true;
                var tileTypes = gridMap.GetNode(currentNode.xPos + x, currentNode.yPos).TileTypes;
                if (tileTypes.Contains(TileType.WallDown))
                    return true;
            }

            return false;
        }
    }
}
