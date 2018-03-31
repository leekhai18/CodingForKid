using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarBehaviour : MonoBehaviour
{

    [SerializeField] float speedX = 10;
    [SerializeField] float speedY = 10;

    int directionOnHorizontal = 0;
    int directionOnVertical = 0;


    bool isReady = false;
    bool isVictory = false;

    [SerializeField] List<Slot> slots;

    [SerializeField] GameObject effectBoom;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && !isVictory)
        {
            Run();
        }
    }

    private void OnMouseDown()
    {
        if (slots[0].item.GetComponent<StartCommand>() != null)
        {
            ExecuteCommand();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Road")
        {
            Debug.Log("No longer in contact with " + collision.gameObject.tag);
            Debug.Log("YOU LOSE");

            Accident();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VictoryGate")
        {
            isVictory = true;
            Debug.Log("VICTORY!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        if (collision.tag == "Fork")
        {
            if (!slots[0].item)
            {
                Stop();
            }
            else
            {
                ExecuteCommand();
            }
        }
    }

    void ExecuteCommand()
    {
        slots[0].item.GetComponent<Command>().Controller(this);
        slots[0].GetComponent<Slot>().gameObject.SetActive(false);
        slots.RemoveAt(0);
    }

    public void StartRun()
    {
        isReady = true;
        TurnRight();
    }
    public void GoDown()
    {
        directionOnHorizontal = 0;
        directionOnVertical = -1;
        transform.DORotate(new Vector3(0, 0, 180), 0.2f);
    }
    public void GoUp()
    {
        directionOnHorizontal = 0;
        directionOnVertical = 1;
        transform.DORotate(new Vector3(0, 0, 360), 0.2f);
    }
    public void TurnLeft()
    {
        directionOnVertical = 0;
        directionOnHorizontal = -1;
        transform.DORotate(new Vector3(0, 0, 90), 0.2f);
    }
    public void TurnRight()
    {
        directionOnVertical = 0;
        directionOnHorizontal = 1;
        transform.DORotate(new Vector3(0, 0, 270), 0.2f);
    }
    public void Stop()
    {
        directionOnHorizontal = 0;
        directionOnVertical = 0;
        isReady = false;
    }

    void Accident()
    {
        Stop();
        this.GetComponent<Renderer>().enabled = false;
        Instantiate(effectBoom, transform.position, Quaternion.identity);
    }

    void Run()
    {
        transform.position = new Vector3(transform.position.x + speedX * directionOnHorizontal * Time.deltaTime, transform.position.y + speedY * directionOnVertical * Time.deltaTime, transform.position.z);
    }
}
