using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerSettings : MonoBehaviour
{
    public static AudioMixerSettings Instance;

    private const string Master = "VolumeMaster";
    private const string Music = "VolumeMusic";
    private const string Sfx = "VolumeSFX";

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private float _currentVolume;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleAudio(bool isEnabled)
    {
        if (isEnabled)
        {
            _audioMixerGroup.audioMixer.SetFloat(Master, -80f);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(Master, _currentVolume);
        }
    }

    public void ChangeMusicVolumeBySlider(float value)
    {
        ChangeBySlider(value, Music);
    }

    public void ChangeSFXVolumeBySlider(float value)
    {
        ChangeBySlider(value, Sfx);
    }

    public void ChangeOverallVolumeBySlider(float value)
    {
        ChangeBySlider(value, Master);

        _currentVolume = Mathf.Log10(value) * 20;
    }

    private void ChangeBySlider(float value, string parameterName)
    {
        _audioMixerGroup.audioMixer.SetFloat(parameterName, Mathf.Log10(value) * 20);
    }
}