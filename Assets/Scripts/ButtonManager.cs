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

public class ButtonManager : MonoBehaviour
{
    public void PlayButton() {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

    public void InstructionsButton() {
        SceneManager.LoadScene("Instructions");
    }

    public void PauseButton() {
        GameObject.Find("PauseMenu").SetActive(true);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
