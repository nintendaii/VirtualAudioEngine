using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataFetcher : MonoBehaviour
{
    public static float[] SamplesData = new float[512];
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumData();
    }

    private void GetSpectrumData()
    {
        _audioSource.GetSpectrumData(SamplesData, 0, FFTWindow.Blackman);
    }
}