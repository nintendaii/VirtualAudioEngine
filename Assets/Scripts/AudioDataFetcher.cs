using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataFetcher : MonoBehaviour
{
    [SerializeField]
    private int amountOfSpectrumValue;

    public static float[] FrequencyBands = new float[8];
    public static float[] SamplesData;
    public static int AmountOfSpectrum;
    private AudioSource _audioSource;
    private void Start()
    {
        AmountOfSpectrum = amountOfSpectrumValue;
        SamplesData = new float[AmountOfSpectrum];
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumData();
        GenerateFrequencyBands();
    }

    private void GetSpectrumData()
    {
        _audioSource.GetSpectrumData(SamplesData, 0, FFTWindow.Blackman);
    }

    private void GenerateFrequencyBands()
    {
        int count = 0;
        for (var i = 0; i < 8; i++)
        {
            var avarage = 0f;
            var samplesCount = (int)Mathf.Pow(2, i) * 2;
            if (i==7)
            {
                samplesCount += 2;
            }

            for (var j = 0; j < samplesCount; j++)
            {
                avarage += SamplesData[count] * (count - 1);
                count++;
            }

            avarage /= count;

            FrequencyBands[i] = avarage * 10;
        }
    }
    
    private void GenerateFrequencyBandsCustom()
    {
        var step = AmountOfSpectrum / 8;
        var currentStep = step;
        var startStep = 0;
        for (var i = 0; i < 8; i++)
        {
            var total = 0f;
            for (var j = startStep; j < currentStep; j++)
            {
                total += SamplesData[j];
            }

            FrequencyBands[i] = total;
            startStep = step;
            currentStep += step;
        }
    }
}