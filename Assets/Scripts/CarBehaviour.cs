using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class CarBehaviour : MonoBehaviour
{

    [SerializeField] float speedX = 10;
    [SerializeField] float speedY = 10;

    int directionOnHorizontal = 0;
    int directionOnVertical = 0;

    
    bool isReady = false;
    bool isVictory = false;

    [SerializeField] GameObject effectBoom;

    float counterExitColliderRoad = 0;
    bool isExitColliderRoad = false;
    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {
        ChangeSkins();
        
    }
    public void ChangeSkins()
    {
        this.GetComponent<SpriteRenderer>().sprite = listOfCar.Instance.carSkins[PlayerPrefs.GetInt("SkinNumber")]; ;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("SkinNumber");
        if (isReady && !isVictory)
        {
            Run();
        }

        if (isExitColliderRoad)
        {
            counterExitColliderRoad += Time.deltaTime;

            if (counterExitColliderRoad > 0.05f)
            {

             

                Accident();
                isExitColliderRoad = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.InitListCommand())
        {
            if (GameManager.Instance.IsBooted())
            {
                GameManager.Instance.ExecuteCommand();
                GameManager.timeBegin = Time.time;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Road"))
        {
            isExitColliderRoad = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Road"))
        {
            isExitColliderRoad = true;
            counterExitColliderRoad = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Home"))
        {
            GameManager.Instance.NextCommand();
            isVictory = true;
            GameManager.timeEnd = Time.time;
            Debug.Log("VICTORY!!!!!!!!!!!!!!!!!!!!!!!!!");
            GameManager.Instance.EndGame("Victory");
        }

        if (collision.CompareTag("Fork"))
        {
            GameManager.Instance.NextCommand();
            GameManager.Instance.ExecuteCommand();
        }

        if (collision.CompareTag("Quiz"))
        {
            GameManager.timeEnd= Time.time;
            Debug.Log("befor"+SceneManagerment.starOfCounting);
            if (SceneManagerment.starOfCounting > 1)
            {
                SceneManagerment.starOfCounting--;

                Debug.Log("after" + SceneManagerment.starOfCounting);
                Stop();
                QuizManager.Instance.InitQuiz(collision.GetComponent<Quiz>());

            }
            else
            {
                Accident();
            }
            
        }
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
        transform.DORotate(new Vector3(0, 0, 0), 0.2f);
    }
    public void GoUp()
    {
        directionOnHorizontal = 0;
        directionOnVertical = 1;
        transform.DORotate(new Vector3(0, 0, 180), 0.2f);
    }
    public void TurnLeft()
    {
        directionOnVertical = 0;
        directionOnHorizontal = -1;
        transform.DORotate(new Vector3(0, 0, -90), 0.2f);
    }
    public void TurnRight()
    {
        directionOnVertical = 0;
        directionOnHorizontal = 1;
        transform.DORotate(new Vector3(0, 0, 90), 0.2f);
    }
    public void Stop()
    {
        directionOnHorizontal = 0;
        directionOnVertical = 0;
        isReady = false;
    }
    public void StopAndWaiting()
    {
        directionOnHorizontal = 0;
        directionOnVertical = 0;
        isReady = false;
        Instantiate(effectBoom, transform.position, Quaternion.identity);
        GameManager.Instance.EndGame("Failed");


    }
    void Accident()
    {

        GameManager.timeEnd = Time.time;

        Stop();
        this.GetComponent<Renderer>().enabled = false;
        Instantiate(effectBoom, transform.position, Quaternion.identity);
        GameManager.Instance.EndGame("Failed");
    }

    public  void Run()
    {
        transform.position = new Vector3(transform.position.x + speedX * directionOnHorizontal * Time.deltaTime, transform.position.y + speedY * directionOnVertical * Time.deltaTime, transform.position.z);
    }
}
