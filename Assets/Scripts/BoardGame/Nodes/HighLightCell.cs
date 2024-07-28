using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Nodes
{
    public class HighLightCell : MonoBehaviour
    {
        private List<GameObject> _highLightWalkablecells;
        public void Init()
        {
            _highLightWalkablecells = new List<GameObject>();
            for (int i = 0; i < transform.childCount; i++)
            {
                var go = transform.GetChild(i).gameObject;
                go.SetActive(false);
                _highLightWalkablecells.Add(go);
            }
        }

        public void SetHighLightCell(Vector3 position)
        {
            var cell = _highLightWalkablecells.FirstOrDefault(c => !c.activeSelf);
            if (cell != null)
            {
                cell.SetActive(true);
                cell.transform.position = position;
            }
        }
        public void ResetAllHighLightCell()
        {
            foreach (var cell in _highLightWalkablecells)
            {
                cell.SetActive(false);
                cell.transform.position = new Vector3(-2, -2);
            }
        }
    }
}
