using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class InstantiateHelper : MonoBehaviour
    {
        private static InstantiateHelper _instance;

        public static InstantiateHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject("InstantiateHelper");
                    _instance = obj.AddComponent<InstantiateHelper>();
                    DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }

        public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Instantiate(prefab, position, rotation);
        }
        public GameObject InstantiatePrefab(GameObject prefab)
        {
            return Instantiate(prefab);
        }
    }
}
