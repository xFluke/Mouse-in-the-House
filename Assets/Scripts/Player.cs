using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask obstacleLayer;

    Animator animator;

    bool isMoving = false;
    Vector3 destination;

    float speed = 1f;

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, 0.5f, obstacleLayer);

        animator.SetInteger("XDirection", 0);
        animator.SetInteger("YDirection", 1);

        if (!isMoving && !hit) {
            destination = transform.position + new Vector3(0.0f, 0.5f, 0.0f);            
        }
    }

    public void MoveDown() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.5f, obstacleLayer);

        animator.SetInteger("XDirection", 0);
        animator.SetInteger("YDirection", -1);

        if (!isMoving && !hit) {
            destination = transform.position - new Vector3(0.0f, 0.5f, 0.0f);       
        }
    }

    public void MoveLeft() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 0.5f, obstacleLayer);

        animator.SetInteger("XDirection", -1);
        animator.SetInteger("YDirection", 0);

        if (!isMoving && !hit) {
            destination = transform.position - new Vector3(0.5f, 0.0f, 0.0f);
        }
    }

    public void MoveRight() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 0.5f, obstacleLayer);

        animator.SetInteger("XDirection", 1);
        animator.SetInteger("YDirection", 0);

        if (!isMoving && !hit) {
            destination = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        }
    }
}
