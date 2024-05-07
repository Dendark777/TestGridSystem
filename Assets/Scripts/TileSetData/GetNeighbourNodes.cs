using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodes
    {
        private readonly GetNeighbourNodes _getNeighbourNodes;

        public GetNeighbourNodes(GetNeighbourNodes getNeighbourNodes = null)
        {
            _getNeighbourNodes = getNeighbourNodes;
        }

        public virtual bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            if (x == 0 && y == 0)
                return true;
            if (!gridMap.CheckPosition(currentNode.xPos + x, currentNode.yPos + y))
                return true;

            var result = false;
            if(_getNeighbourNodes != null)
            {
                result = _getNeighbourNodes.CheckNeighbourNode(x, y, currentNode, gridMap);
            }

            return result;
        }
    }
}
