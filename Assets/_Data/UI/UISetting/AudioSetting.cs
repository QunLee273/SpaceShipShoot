using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : ShipMonoBehaviour
{
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider SFXSlider;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAudioMixer();
        this.LoadSliderMusic();
        this.LoadSliderSFX();
    }

    protected override void Start()
    {
        base.Start();

        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    protected void LoadAudioMixer()
    {
        if (this.audioMixer != null) return;
        this.audioMixer = Resources.Load<AudioMixer>("Audio/AudioMixer");
        Debug.Log(transform.name + ": LoadAudioMixer", gameObject);
    }

    protected void LoadSliderMusic()
    {
        if (this.musicSlider != null) return;
        Transform slider = transform.Find("AudioSourceMusic");
        if (slider != null)
        {
            this.musicSlider = slider.GetComponentInChildren<Slider>();
            Debug.Log(transform.name + ": LoadSliderMusic", gameObject);
        }
    }

    protected void LoadSliderSFX()
    {
        if (this.SFXSlider != null) return;
        Transform slider = transform.Find("AudioSourceSFX");
        if (slider != null)
        {
            this.SFXSlider = slider.GetComponentInChildren<Slider>();
            Debug.Log(transform.name + ": LoadSliderSFX", gameObject);
        }  
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    protected void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
