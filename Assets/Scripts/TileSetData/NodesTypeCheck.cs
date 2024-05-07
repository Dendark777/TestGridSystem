using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.TileSetData
{
    public static class NodesTypeCheck
    {
        public static Dictionary<TileType, GetNeighbourNodes> TypeChecks { get; private set; } = new Dictionary<TileType, GetNeighbourNodes>
        {
            {TileType.None, new GetNeighbourNodes(new GetNeighbourNodesNone()) },
            {TileType.Norm, new GetNeighbourNodes(new GetNeighbourNodesNormal()) },
            {TileType.WallDown, new GetNeighbourNodes(new GetNeighbourNodesWallDown()) },
            {TileType.WallLeft, new GetNeighbourNodes(new GetNeighbourNodesWallLeft()) },
            {TileType.WallRight, new GetNeighbourNodes(new GetNeighbourNodesWallRight()) },
            {TileType.WallUp, new GetNeighbourNodes(new GetNeighbourNodesWallUp()) },
            {TileType.WallUpRight, new GetNeighbourNodes(new GetNeighbourNodesWallUp()) },
            {TileType.WallUpLeft, new GetNeighbourNodes(new GetNeighbourNodesWallUp()) },
            {TileType.WallDownRight, new GetNeighbourNodes(new GetNeighbourNodesWallUp()) },
            {TileType.WallDownLeft, new GetNeighbourNodes(new GetNeighbourNodesWallUp()) }
        };
    }
}
