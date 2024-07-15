using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner _instance;

        public static CoroutineRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject("CoroutineRunner");
                    _instance = obj.AddComponent<CoroutineRunner>();
                    DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }

        public static Coroutine StartCoroutineStatic(IEnumerator coroutine)
        {
            return Instance.StartCoroutine(coroutine);
        }

        public static void StopCoroutineStatic(Coroutine coroutine)
        {
            if (_instance != null)
            {
                Instance.StopCoroutine(coroutine);
            }
        }
    }
}
