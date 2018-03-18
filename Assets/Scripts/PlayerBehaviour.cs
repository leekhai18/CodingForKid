using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] float speedX = 10;
    [SerializeField] float speedY = 10;

    int directionOnHorizontal = 0;
    int directionOnVertical = 0;


    bool isReady = false;
    bool isVictory = false;

    [SerializeField] List<Slot> slots;
    int index = 0;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (isReady && !isVictory) {
            Run();
        }
    }

    private void OnMouseDown()
    {
        if (slots[0].item.name == "Start") {
            isReady = true;
            TurnRight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Road") {
            Debug.Log("No longer in contact with " + collision.gameObject.tag);
            Debug.Log("YOU LOSE");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VictoryGate") {
            isVictory = true;
            Debug.Log("VICTORY!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        if (collision.tag == "Fork") {
            if (!slots[index].item) {
                Stop();
            } else {
                switch (slots[index].item.name)
                {
                    case "ArrowDown":
                        TurnDown();
                        break;
                    case "ArrowUp":
                        TurnUp();
                        break;
                    case "ArrowLeft":
                        TurnLeft();
                        break;
                    case "ArrowRight":
                        TurnRight();
                        break;

                    default:
                        break;
                }
            }
        }
    }

    void TurnDown() {
        directionOnHorizontal = 0;
        directionOnVertical = -1;
        transform.DORotate(new Vector3(0, 0, 180), 0.2f);
        index++;
    }
    void TurnUp() {
        directionOnHorizontal = 0;
        directionOnVertical = 1;
        transform.DORotate(new Vector3(0, 0, 360), 0.2f);
        index++;
    }
    void TurnLeft() {
        directionOnVertical = 0;
        directionOnHorizontal = -1;
        transform.DORotate(new Vector3(0, 0, 90), 0.2f);
        index++;
    }
    void TurnRight() {
        directionOnVertical = 0;
        directionOnHorizontal = 1;
        transform.DORotate(new Vector3(0, 0, 270), 0.2f);
        index++;
    }
    void Stop() {
        directionOnHorizontal = 0;
        directionOnVertical = 0;
        isReady = false;
    }


    void Run()
    {
        transform.position = new Vector3(transform.position.x + speedX*directionOnHorizontal*Time.deltaTime, transform.position.y + speedY*directionOnVertical*Time.deltaTime, transform.position.z);
    }
}
