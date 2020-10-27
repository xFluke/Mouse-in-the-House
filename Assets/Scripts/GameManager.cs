/*
File name: GameManager.cs
Name: Miko Man 101127881
Date Last Modified: OCt 4 2020
Description: This is the game manager which will be in charge of tracking Win/Loss Conditions, as well as various UI button behaviors
Revision History:
Oct 4: - Added Pause/Resume and Quit functionalities
       - Temporary GameOver test button
Oct 25: - Added a way to automatically spawn cheese
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // UI Variables
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Canvas gameplayUI;
    [SerializeField] GameObject gameplayObjects;
    public SpriteRenderer[] spriteRenderers;
    [SerializeField]
    private Text scoreText;

    // Gameplay variables
    public Tilemap tilemap;

    [SerializeField]
    private GameObject cheesePrefab;
    private int currentScore = 0;

    [SerializeField]
    private int cheeseCount = 0;


    private void Awake() {
        spriteRenderers = gameplayObjects.GetComponentsInChildren<SpriteRenderer>();

        tilemap = GameObject.FindGameObjectWithTag("Floor").GetComponent<Tilemap>();
    }

    private void Start() {
        SpawnCheese();
    }

    private void SpawnCheese() {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] floorTiles = tilemap.GetTilesBlock(bounds);

        Transform cheeseParentTransform = GameObject.Find("GameplayObjects").transform;

        // Find all floor tiles and instantiate a cheese object on them
        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = floorTiles[x + y * bounds.size.x];

                if (tile != null) {
                    Instantiate(cheesePrefab, new Vector3(0.5f * x - 5.25f, 0.5f * y - 4.75f, 0), Quaternion.identity, cheeseParentTransform);
                    cheeseCount += 1;
                }
            }
        }
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

    public void AddScore(int score) {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void DecrementCheese() {
        cheeseCount--;

        if (cheeseCount <= 0) {
            ButtonManager.Instance.SetScore(currentScore);
            Debug.Log(currentScore);
            ButtonManager.Instance.Win();
            
            
        }
    }

    
}
