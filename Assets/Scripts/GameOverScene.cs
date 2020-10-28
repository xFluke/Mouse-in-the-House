/*
File name: GameOverScene.cs
Name: Miko Man 101127881
Date Last Modified: Oct 27 2020
Description: Just a script to set the score text
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.SetGameOverScoreText();
    }

}
