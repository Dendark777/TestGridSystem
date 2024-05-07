using Assets.Scripts.Nodes;
using Assets.Scripts.TileSetData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile Set")]
public class TileSet : ScriptableObject
{
    public List<TileListEntry> Tiles;

    public TileBase GetTile(Node node)
    {
        var tile = Tiles.Find(t => t.TileType == node.TileTypes[0]);
        return tile?.Tiles[1];
    }

    public TileType GetTileType(TileBase tile, out int index)
    {
        index = -1;
        foreach (var entry in Tiles)
        {
            if (entry.Tiles.Contains(tile))
            {
                index = entry.Tiles.IndexOf(tile);
                return entry.TileType;
            }
        }

        // Если тайл не найден, вернуть значение по умолчанию
        return default;
    }
}
[Serializable]
public class TileListEntry
{
    public TileType TileType;
    public List<TileBase> Tiles;
}
