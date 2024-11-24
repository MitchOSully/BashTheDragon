using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource m_musicSource;
    [SerializeField] AudioSource m_SFXSource;

    [Header("Audio clips")]
    public AudioClip m_backgroundMusic;
    public AudioClip m_yarronHurtClip;

    private void Start()
    {
        m_musicSource.clip = m_backgroundMusic;
        m_musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        m_SFXSource.PlayOneShot(clip);
    }
}
