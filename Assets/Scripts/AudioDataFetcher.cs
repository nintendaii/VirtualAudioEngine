using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataFetcher : MonoBehaviour
{
    public static float[] SamplesData;
    public int amountOfSpectrumValue;
    public static int amountOfSpectrum;
    private AudioSource _audioSource;
    private void Start()
    {
        amountOfSpectrum = amountOfSpectrumValue;
        SamplesData = new float[amountOfSpectrum];
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