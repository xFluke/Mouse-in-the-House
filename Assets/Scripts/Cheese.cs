/*
File name: Cheese.cs
Name: Miko Man 101127881
Date Last Modified: Oct 25 2020
Description: This is the script for the Cheese object
Revision History:
Oct 25: - Gets destroyed upon contact with player and adds score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().AddScore(100);
        }
    }
}
