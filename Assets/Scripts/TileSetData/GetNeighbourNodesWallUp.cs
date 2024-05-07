using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Build.Content;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodesWallUp : GetNeighbourNodes
    {
        public GetNeighbourNodesWallUp(GetNeighbourNodes getNeighbourNodes = null) : base(getNeighbourNodes)
        {
        }

        public override bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            if (y == 1)
            {
                if (x == 0)
                    return true;
                var tileTypes = gridMap.GetTile(currentNode.xPos + x, currentNode.yPos).TileTypes;
                if (tileTypes.Contains( TileType.WallUp))
                    return true;
            }
            if (y == -1)
            {
                var tileTypes = gridMap.GetTile(currentNode.xPos + x, currentNode.yPos + y).TileTypes;
                if (tileTypes.Contains(TileType.WallUp))
                    return true;
            }

            return false;
        }
    }
}
