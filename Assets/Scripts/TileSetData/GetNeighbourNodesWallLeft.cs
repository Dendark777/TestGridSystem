using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodesWallLeft : GetNeighbourNodes
    {
        public GetNeighbourNodesWallLeft(GetNeighbourNodes getNeighbourNodes = null) : base(getNeighbourNodes)
        {
        }

        public override bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            if (x == 1)
            {
                var tileTypes = gridMap.GetTile(currentNode.xPos + x, currentNode.yPos + y).TileTypes;
                if (tileTypes.Contains(TileType.WallLeft))
                    return true;
            }
            if (x == -1)
            {
                if (y == 0)
                    return true;
                var tileTypes = gridMap.GetTile(currentNode.xPos, currentNode.yPos + y).TileTypes;
                if (tileTypes.Contains(TileType.WallLeft))
                    return true;
            }

            return false;
        }
    }
}
