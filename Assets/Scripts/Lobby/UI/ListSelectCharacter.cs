using Assets.Scripts.Constants;
using Assets.Scripts.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ListSelectCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cellCharacter;
        [SerializeField]
        private RectTransform _tilePanel;

        private void Start()
        {
            foreach (var item in PlayerConstants.ListPersons)
            {
                AddTile(item.Value);
            }
        }
        public virtual void AddTile(BaseParameters parameters)
        {
            GameObject newTile = Instantiate(_cellCharacter, _tilePanel);
            newTile.SetActive(true);
            newTile.GetComponent<SelectCharacterCell>().AddCell(parameters);
        }
    }
}
