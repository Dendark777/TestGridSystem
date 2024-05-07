using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public class GetNeighbourNodesNone : GetNeighbourNodes
    {
        public GetNeighbourNodesNone(GetNeighbourNodes getNeighbourNodes = null) : base(getNeighbourNodes)
        {
        }

        public override bool CheckNeighbourNode(int x, int y, PathNode currentNode, GridMap gridMap)
        {
            return false;
        }
    }
}
