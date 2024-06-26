using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players.Chip
{
    public class ChipEvent : MonoBehaviour
    {
        //private void ClickOnCharacterMouseLeft(GameObject clickedObject)
        //{
        //    if (movining)
        //    {
        //        return;
        //    }
        //    if (!clickedObject.TryGetComponent<ChipBase>(out selectedChip))
        //    {
        //        return;
        //    }
        //    var nodeClicked = selectedChip.Node;
        //    path = null;

        //    if (!gridManager.CheckPosition(nodeClicked.PosX, nodeClicked.PosY))
        //    {
        //        return;
        //    }

        //    List<PathNode> toHighlight = new List<PathNode>();
        //    pathfinding.Clear();
        //    pathfinding.CalculateWalkableTerrain(selectedChip.Node,
        //                                         selectedChip.MaxCellMove,
        //                                         ref toHighlight);
        //    for (int i = 0; i < toHighlight.Count; i++)
        //    {
        //        var pos = toHighlight[i].GetPosition();
        //        highLghitCells.SetHighLightCell(pos);
        //    }
        //}
    }
}
