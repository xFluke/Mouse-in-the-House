/*
File name: GameManager.cs
Name: Miko Man 101127881
Date Last Modified: OCt 4 2020
Description: This is the game manager which will be in charge of tracking Win/Loss Conditions, as well as various UI button behaviors
Revision History:
Oct 4: - Added Pause/Resume and Quit functionalities
       - Temporary GameOver test button
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Canvas gameplayUI;
    [SerializeField] GameObject gameplayObjects;

    public SpriteRenderer[] spriteRenderers;

    private void Awake() {
        spriteRenderers = gameplayObjects.GetComponentsInChildren<SpriteRenderer>();
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void PauseButton() {
        pauseMenu.SetActive(true);
        gameplayUI.GetComponent<CanvasGroup>().alpha = 0.1f;
        MakeGameplayObjectsTransparent();
    }

    private void MakeGameplayObjectsTransparent() {
        foreach (SpriteRenderer sr in spriteRenderers) {
            Color tempColor = sr.color;
            tempColor.a = 0.1f;
            sr.color = tempColor;
        }

        Color tempColor2 = FindObjectOfType<Tilemap>().color;
        tempColor2.a = 0.1f;
        FindObjectOfType<Tilemap>().color = tempColor2;
    }

    private void MakeGameplayObjectsOpaque() {
        foreach (SpriteRenderer sr in spriteRenderers) {
            Color tempColor = sr.color;
            tempColor.a = 1f;
            sr.color = tempColor;
        }

        Color tempColor2 = FindObjectOfType<Tilemap>().color;
        tempColor2.a = 1f;
        FindObjectOfType<Tilemap>().color = tempColor2;
    }

    public void ResumeButton() {
        pauseMenu.SetActive(false);
        gameplayUI.GetComponent<CanvasGroup>().alpha = 1f;
        MakeGameplayObjectsOpaque();
    }

    public void QuitButton() {
        Application.Quit();
    }
}
