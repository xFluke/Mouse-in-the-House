using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float maxY = 3f;
    float minY = -3.5f;

    float maxX = 2f;
    float minX = -1.8f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = player.transform.position;
        temp.x = Mathf.Clamp(temp.x, minX, maxX);
        temp.y = Mathf.Clamp(temp.y, minY, maxY);
        temp.z = -10f;
        transform.position = temp;
    }
}
