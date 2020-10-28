/*
File name: Player.cs
Name: Miko Man 101127881
Date Last Modified: Oct 25 2020
Description: This is the controller for the player
Revision History:
Oct 25: - Added basic movement functionality
        - Added obstacle detection
        - Added movement naimations
 */

using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip MeowSound;

    public LayerMask obstacleLayer;

    Animator animator;

    bool isMoving = false;
    Vector3 destination;
    bool respawning = false;


    float speed = 1f;

    int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != destination) {
            isMoving = true;
        }
        else {
            isMoving = false;
        }

        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
    }

    public void MoveUp() {
        if (!respawning) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, 0.5f, obstacleLayer);

            animator.SetInteger("XDirection", 0);
            animator.SetInteger("YDirection", 1);

            if (!isMoving && !hit) {
                destination = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
            }
        }
    }

    public void MoveDown() {
        if (!respawning) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.5f, obstacleLayer);

            animator.SetInteger("XDirection", 0);
            animator.SetInteger("YDirection", -1);

            if (!isMoving && !hit) {
                destination = transform.position - new Vector3(0.0f, 0.5f, 0.0f);
            }
        }
    }

    public void MoveLeft() {
        if (!respawning) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 0.5f, obstacleLayer);

            animator.SetInteger("XDirection", -1);
            animator.SetInteger("YDirection", 0);

            if (!isMoving && !hit) {
                destination = transform.position - new Vector3(0.5f, 0.0f, 0.0f);
            }
        }
    }

    public void MoveRight() {
        if (!respawning) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 0.5f, obstacleLayer);

            animator.SetInteger("XDirection", 1);
            animator.SetInteger("YDirection", 0);

            if (!isMoving && !hit) {
                destination = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Cat" && !respawning) {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        respawning = true;
        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a = 0;
        GetComponent<SpriteRenderer>().color = temp;
        SoundManager.Instance.PlaySFX(MeowSound);
        yield return new WaitForSeconds(2f);

        respawning = false;
        transform.position = new Vector3(0.8f, 0.75f, 0);
        destination = transform.position;
        temp.a = 255;
        GetComponent<SpriteRenderer>().color = temp;

        Destroy(GameObject.Find("HP_" + health.ToString()));
        health--;

        if (health <= 0) {
            SoundManager.Instance.SetScore(FindObjectOfType<GameManager>().GetScore());
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
