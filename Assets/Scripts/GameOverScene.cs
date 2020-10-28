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

    // Update is called once per frame
    void Update()
    {
        
    }
}
