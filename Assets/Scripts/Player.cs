using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isMoving = false;
    Vector3 destination;

    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
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
        if (!isMoving) {
            destination = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        }
    }

    public void MoveDown() {
        if (!isMoving) {
            destination = transform.position - new Vector3(0.0f, 0.5f, 0.0f);
        }
    }

    public void MoveLeft() {
        if (!isMoving) {
            destination = transform.position - new Vector3(0.5f, 0.0f, 0.0f);
        }
    }

    public void MoveRight() {
        if (!isMoving) {
            destination = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        }
    }
}
