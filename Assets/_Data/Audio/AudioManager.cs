using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ShipMonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource SFXSource;

    [Header("---Audio Clip---")]
    [SerializeField] public AudioClip musicClip;
    [SerializeField] public AudioClip atkClip;
    [SerializeField] public AudioClip deadClip;
    [SerializeField] public AudioClip hitClip;
    [SerializeField] public AudioClip warpClip;

    [SerializeField] private AudioClip[] listBackground;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMusicSource();
        this.LoadSFXSource();
    }

    protected override void Start()
    {
        base.Start();

        if (musicSource != null)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }

    protected void LoadMusicSource()
    {
        if (this.musicSource != null) return;
        this.musicSource = transform.Find("Music")?.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadMusicSource", gameObject);
    }

    protected void LoadSFXSource()
    {
        if (this.SFXSource != null) return;
        this.SFXSource = transform.Find("SFX")?.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadSFXSource", gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
