using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ParametricItemsController : MonoBehaviour
    {
        public int amountOfSpectrum;
        public float maxScale;
        public GameObject parametricCube;
        public GameObject[] parametricCubesArray;

        private void Start()
        {
            amountOfSpectrum = AudioDataFetcher.AmountOfSpectrum;
            parametricCubesArray = new GameObject[amountOfSpectrum];
            var angle = 360f/amountOfSpectrum;
            var val = 2;
            var iter = 1;
            while (val!=amountOfSpectrum)
            {
                val *=2;
                iter++;
            }

            for (var i = 0; i < amountOfSpectrum; i++)
            {
                var parCube = Instantiate(parametricCube);
                parCube.transform.position = transform.position;
                parCube.transform.parent = transform;
                parCube.name = $"ParametricCube{i}";
                transform.eulerAngles = new Vector3(0, -angle*i, 0);
                parCube.transform.position = Vector3.forward * 25 * (iter-5);
                parametricCubesArray[i] = parCube;
            }
        }

        private void Update()
        {
            for (var i = 0; i < amountOfSpectrum; i++)
            {
                if (parametricCubesArray != null)
                {
                    parametricCubesArray[i].transform.localScale = new Vector3(1, AudioDataFetcher.SamplesData[i]*maxScale + 1, 1);
                }
            } 
           
        }
    }
}