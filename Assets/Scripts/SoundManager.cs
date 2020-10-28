/*
File name: SoundManager.cs
Name: Miko Man 101127881
Date Last Modified: OCt 27 2020
Description: This is the sound manager which will be in charge of playing sound effects and background music
Revision History:
Oct 26: - Created basic structure for playing sound effects and music

Oct 27: - Added more functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsAudioSource;
    public AudioSource MusicAudioSource;

    public AudioClip MainMenuMusic;
    public AudioClip GameMusic;

    public static SoundManager Instance = null;

    // Temporary work around for keeping score
    int score = 0;

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

    public void PlayGameMusic() {
        MusicAudioSource.clip = GameMusic;
        MusicAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        EffectsAudioSource.clip = clip;
        EffectsAudioSource.Play();
    }

    public void StopMusic() {
        MusicAudioSource.Stop();
    }

    // Really bad practice but I decided to save the score here because this script persists throughout the whole game
    public void SetScore(int _score) {
        score = _score;
    }

    public void SetGameOverScoreText() {
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score.ToString();
    }

    public void PlayMainMenuMusic() {
        if (MusicAudioSource.clip != MainMenuMusic) {
            MusicAudioSource.clip = MainMenuMusic;
            MusicAudioSource.Play();
        }
    }
}
