using UnityEngine;

namespace DefaultNamespace
{
    public class ParametricCubeController : MonoBehaviour
    {
        public int band;
        public float startScale, scaleMultiplier;

        private void Update()
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                AudioDataFetcher.FrequencyBands[band] * scaleMultiplier + startScale,
                transform.localScale.z);
        }
    }
}