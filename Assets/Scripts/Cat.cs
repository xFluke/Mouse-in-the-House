/*
File name: Cat.cs
Name: Miko Man 101127881
Date Last Modified: Oct 27 2020
Description: This is the script for the cat enemy
Revision History:
Oct 25: - Added basic movement functionality
        - Added obstacle detection
        - Partially implemented movement AI

Oct 26: - Fully implemented movement AI. Not the best but satisfied with current state.

Oct 27: - Stop movement when game is paused
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NUM_OF_DIRECTION
    };

    public LayerMask obstacleLayer;
    [SerializeField]
    Direction direction;
    [SerializeField]
    Direction nextDirection;
    Vector3 destination;
    public bool isMoving = false;
    float speed = 1f;

    Animator animator;

    bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause) { 

        if (transform.position != destination) {
            isMoving = true;
        }
        else {
            isMoving = false;
        }

            if (isMoving) {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            }
            else {
                if (direction == Direction.UP) {
                    MoveUp();
                }
                else if (direction == Direction.DOWN) {
                    MoveDown();
                }
                else if (direction == Direction.LEFT) {
                    MoveLeft();
                }
                else if (direction == Direction.RIGHT) {
                    MoveRight();
                }
            }
        }

        //Debugging purposes
        //Debug.DrawRay(transform.position - new Vector3(0, 0.15f, 0), Vector3.up - new Vector3(0, 0.6f, 0), Color.red);
        //Debug.DrawRay(transform.position - new Vector3(0, 0.15f, 0), Vector3.down + new Vector3(0, 0.6f, 0), Color.red);
        //Debug.DrawRay(transform.position - new Vector3(0, 0.15f, 0), Vector3.left + new Vector3(0.6f, 0, 0), Color.red);
        //Debug.DrawRay(transform.position - new Vector3(0, 0.15f, 0), Vector3.right - new Vector3(0.6f, 0, 0), Color.red);

    }

    private void MoveUp() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.up, 0.4f, obstacleLayer);

        animator.SetInteger("XDirection", 0);
        animator.SetInteger("YDirection", 1);

        if (!isMoving && !hit) {
            destination = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        }

        if (hit) {
            SwitchDirection();
        }
    }

    private void MoveDown() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.down, 0.4f, obstacleLayer);

        animator.SetInteger("XDirection", 0);
        animator.SetInteger("YDirection", -1);

        if (!isMoving && !hit) {
            destination = transform.position - new Vector3(0.0f, 0.5f, 0.0f);
        }

        if (hit) {
            SwitchDirection();
        }
    }

    private void MoveLeft() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.left, 0.4f, obstacleLayer);

        animator.SetInteger("XDirection", -1);
        animator.SetInteger("YDirection", 0);


        if (!isMoving && !hit) {
            destination = transform.position - new Vector3(0.5f, 0.0f, 0.0f);
        }

        if (hit) {
            SwitchDirection();
        }
    }

    private void MoveRight() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.right, 0.4f, obstacleLayer);

        animator.SetInteger("XDirection", 1);
        animator.SetInteger("YDirection", 0);

        if (!isMoving && !hit) {
            destination = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        }

        if (hit) {
            SwitchDirection();
        }
    }

    // Function for making the cat choose a random direction to move in
    public void PickRandomDirection() {
        Direction tempDirection = direction;
        bool continuePicking = true;

        do {
            tempDirection = (Direction)Random.Range(0, (int)Direction.NUM_OF_DIRECTION);

            if (tempDirection != GetOppositeDirection(direction) && !SomethingInTheWay(tempDirection)) {
                continuePicking = false;
            }

        } while (continuePicking);

        direction = tempDirection;
        //Debug.Log("Random Direction: " + direction);
    }

    // Helper Function for determining the opposite of a given direction
    private Direction GetOppositeDirection(Direction dir) {
        switch (dir) {
            case Direction.UP:
                return Direction.DOWN;
            case Direction.DOWN:
                return Direction.UP;
            case Direction.LEFT:
                return Direction.RIGHT;
            case Direction.RIGHT:
                return Direction.LEFT;
            default:
                return Direction.NUM_OF_DIRECTION;
        }
    }

    // Helper Function for determining if there is something in the way in a given direction
    private bool SomethingInTheWay(Direction dir) {
        switch (dir) {
            case Direction.UP:
                RaycastHit2D upHit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.up, 0.4f, obstacleLayer);
                return upHit;
            case Direction.DOWN:
                RaycastHit2D downHit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.down, 0.4f, obstacleLayer);
                return downHit;
            case Direction.LEFT:
                RaycastHit2D leftHit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.left, 0.4f, obstacleLayer);
                return leftHit;
            case Direction.RIGHT:
                RaycastHit2D rightHit = Physics2D.Raycast(transform.position - new Vector3(0, 0.15f, 0), Vector3.right, 0.4f, obstacleLayer);
                return rightHit;
            default:
                return true;
        }
    }

    // Function for switching directions after reaching a dead end
    private void SwitchDirection() {
        switch (direction) {
            case Direction.UP:
            case Direction.DOWN:
                if (SomethingInTheWay(Direction.LEFT)) {
                    direction = Direction.RIGHT;
                }
                else {
                    direction = Direction.LEFT;
                }
                break;

            case Direction.LEFT:
            case Direction.RIGHT:
                if (SomethingInTheWay(Direction.UP)) {
                    direction = Direction.DOWN;
                }
                else {
                    direction = Direction.UP;
                }
                break;
        }
    }

    // Public function for other classes to influence cat movement
    public void MoveInDirection(Direction dir) {
        if (dir == Direction.UP) {
            direction = Direction.UP;
        }
        else if (dir == Direction.DOWN) {
            direction = Direction.DOWN;
        }
        else if (dir == Direction.LEFT) {
            direction = Direction.LEFT;
        }
        else if (dir == Direction.RIGHT) {
            direction = Direction.RIGHT;
        }
    }

    public void Pause() {
        pause = true;
    }

    public void Unpause() {
        pause = false;
    }
}
