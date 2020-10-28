/*
File name: ButtonManager.cs
Name: Miko Man 101127881
Date Last Modified: OCt 4 2020
Description: This is the button manager which will be in charge of UI button behaviors in all the scenes except the Game scene.
Revision History:
Oct 4: - Added all button behaviors for all the scenes except the Game scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public AudioClip buttonSFX;

    private int score = 0;

    public void PlayButton() {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlaySFX(buttonSFX);
        SoundManager.Instance.PlayGameMusic();
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMainMenuButton() {
        SoundManager.Instance.PlaySFX(buttonSFX);

        SoundManager.Instance.PlayMainMenuMusic();
        SceneManager.LoadScene("MainMenu");
    }

    public void InstructionsButton() {
        SoundManager.Instance.PlaySFX(buttonSFX);
        SceneManager.LoadScene("Instructions");
    }

    public void PauseButton() {
        SoundManager.Instance.PlaySFX(buttonSFX);
        GameObject.Find("PauseMenu").SetActive(true);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void SetScore(int _score) {
        score = _score;
    }


    public void SwitchToGameOverScene() {
        SceneManager.LoadScene("GameOver");
    }
}
