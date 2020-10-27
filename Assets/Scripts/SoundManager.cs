/*
File name: SoundManager.cs
Name: Miko Man 101127881
Date Last Modified: OCt 26 2020
Description: This is the sound manager which will be in charge of playing sound effects and background music
Revision History:

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsAudioSource;
    public AudioSource MusicAudioSource;

    public AudioClip MainMenuMusic;

    public static SoundManager Instance = null;

    void Awake() {
        // Singleton Pattern
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        PlayMusic(MainMenuMusic);
    }

    public void PlayMusic(AudioClip clip) {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        EffectsAudioSource.clip = clip;
        EffectsAudioSource.Play();
    }
}
