/*
File name: Intersection.cs
Name: Miko Man 101127881
Date Last Modified: Oct 25 2020
Description: This is the script for each Intersection tile
Revision History:
Oct 25: - Make cat pick a random direction upon contact

Oct 26: - Added a way to force a direction for debugging purposes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    public bool manualOverride = false;
    public Cat.Direction overrideDirection;

    private void OnTriggerEnter2D(Collider2D collision) {
        

        if (collision.gameObject.tag == "Cat") {
            if (manualOverride) {
                collision.GetComponent<Cat>().MoveInDirection(overrideDirection);
            }
            else {
                collision.GetComponent<Cat>().PickRandomDirection();
            }
        }
    }
}
