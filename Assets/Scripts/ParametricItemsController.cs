using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ParametricItemsController : MonoBehaviour
    {
        public float maxScale;
        public GameObject parametricCube;
        public GameObject[] parametricCubesArray = new GameObject[512];

        private void Start()
        {
            for (var i = 0; i < 512; i++)
            {
                var parCube = Instantiate(parametricCube);
                parCube.transform.position = transform.position;
                parCube.transform.parent = transform;
                parCube.name = $"ParametricCube{i}";
                transform.eulerAngles = new Vector3(0, -.703125f*i, 0);
                parCube.transform.position = Vector3.forward * 100;
                parametricCubesArray[i] = parCube;
            }
        }

        private void Update()
        {
            for (var i = 0; i < 512; i++)
            {
                if (parametricCubesArray != null)
                {
                    parametricCubesArray[i].transform.localScale = new Vector3(1, AudioDataFetcher.SamplesData[i]*maxScale + 1, 1);
                }
            }
        }
    }
}