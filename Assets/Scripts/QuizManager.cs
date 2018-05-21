using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : Singleton<QuizManager>
{
    public GameObject oneMoreTurn;
    public GameObject itemController;
    public GameObject quizPannel;
    public GameObject quizBackground;
    private Quiz currentQuiz;
    [SerializeField]
    private int currentID;
    [SerializeField]
    private Text question;

    [SerializeField]
    private Image signboard;

    [SerializeField]
    private List<Text> answers;

    [SerializeField]
    private List<Text> results;

    [SerializeField]
    private Animator animator;
    public bool CheckEnd = true;
    private void Start()
    {
       
    }

    public void InitQuiz(Quiz quiz)
    {
        SetCurrentQuiz(quiz);
     //   animator.SetTrigger("Refresh");
        quizPannel.SetActive(true);
        quizBackground.SetActive(true);
    }

    public void SetCurrentQuiz(Quiz quiz)
    {

        currentQuiz = quiz;

        currentID = quiz.GetComponent<Quiz>().signboard.GetComponent<SignalInformationShowController>().ID;
       
            Item item = ItemDataBase.GetItem(currentID);
      
            signboard.sprite = item.iconSprite;
            question.text = currentQuiz.Question;
            //set giá trị random
            int ex1 = currentID;
            int ex2 = currentID;
            int ex3 = currentID;
            do
            {
                ex1 = (int)(Random.Range(0,(int)( ItemDataBase.Getlengh() / 2)));
            } while (ex1 == currentID);
            do
            {
                ex2 = (int)(Random.Range(ItemDataBase.Getlengh() / 2 + 1, ItemDataBase.Getlengh()-1));
            } while (ex2 == currentID);
            if (currentQuiz.correct == 0 || currentQuiz.correct > 3 || currentQuiz.correct < 0)
            {
                ex3 = (int)Random.Range(0f, 3f);
            }
            Debug.Log("Item 1 ID = " + ex1);
             Debug.Log("Item 2 ID = " + ex2);
             Item item1 = ItemDataBase.GetItem(ex1);
            Item item2 = ItemDataBase.GetItem(ex2);
            switch (ex3)
            {
                case 0:
                    {
                        // câu 1 đúng
                        currentQuiz.correct = 0;
                        int ex4 = (int)Random.Range(0f, 4f);
                        if (ex4 > 2)
                        {
                            results[0].text = "CORRECT";
                            results[1].text = "FALSE";
                            results[2].text = "FALSE";

                            //
                            answers[0].text = item.itemDesc;
                            answers[1].text = item1.itemDesc;
                            answers[2].text = item2.itemDesc;
                        }
                        else
                        {
                            results[0].text = "CORRECT";
                            results[1].text = "FALSE";
                            results[2].text = "FALSE";

                            //
                            answers[0].text = item.itemDesc;
                            answers[1].text = item2.itemDesc;
                            answers[2].text = item1.itemDesc;

                        }
                        break;
                    }
                case 1:
                    {
                        // câu 2 đúng

                        currentQuiz.correct = 1;
                        int ex4 = (int)Random.Range(0f, 4f);
                        if (ex4 > 2)
                        {
                            results[0].text = "FALSE";
                            results[1].text = "CORRECT";
                            results[2].text = "FALSE";

                            //
                            answers[0].text = item1.itemDesc;
                            answers[1].text = item.itemDesc;
                            answers[2].text = item2.itemDesc;
                        }
                        else
                        {
                            results[0].text = "FALSE";
                            results[1].text = "CORRECT";
                            results[2].text = "FALSE";

                            //
                            answers[0].text = item2.itemDesc;
                            answers[1].text = item.itemDesc;
                            answers[2].text = item1.itemDesc;

                        }
                        break;
                    }
                default:
                    {
                        // câu 3 đúng

                        currentQuiz.correct = 2;
                        int ex4 = (int)Random.Range(0f, 4f);
                        if (ex4 > 2)
                        {
                            results[0].text = "FALSE";
                            results[1].text = "FALSE";
                            results[2].text = "CORRECT";

                            //
                            answers[0].text = item1.itemDesc;
                            answers[1].text = item2.itemDesc;
                            answers[2].text = item.itemDesc;
                        }
                        else
                        {
                            results[0].text = "FALSE";
                            results[1].text = "FALSE";
                            results[2].text = "CORRECT";

                            //
                            answers[0].text = item2.itemDesc;
                            answers[1].text = item1.itemDesc;
                            answers[2].text = item.itemDesc;
                        }
                        break;

                    }
            }

       

    }

    public void UserSelectA()
    {
        animator.SetTrigger("A");

        if (currentQuiz.correct == 0)
        {
            Debug.Log("You have only one more turn!");
            CheckEnd = false;
        }
        else
        {
            CheckEnd = true;
            Debug.Log("GAME OVER!");
        }

        CarProcessing();
    }

    public void UserSelectB()
    {
        animator.SetTrigger("B");
        if (currentQuiz.correct == 1)
        {
            Debug.Log("You have only one more turn!");

            CheckEnd = false;
        }
        else
        {
            CheckEnd = true;
            Debug.Log("GAME OVER!");
        }

        CarProcessing();
    }
    public void UserSelectC()
    {
        animator.SetTrigger("C");

        if (currentQuiz.correct == 2)

        {
            CheckEnd = false;
            Debug.Log("You have only one more turn!");
        }
        else

        {

            CheckEnd = true;
            Debug.Log("GAME OVER!");
        }
        CarProcessing();
    }
    public void CarProcessing()
    {
        if (CheckEnd == true)
            GameManager.Instance.EndGame("Failed");
        else if (CheckEnd == false)
        {
            StartCoroutine(Wait2scToDis(2));
            StartCoroutine(Wait2scToReplay(5));
        }
       
    }
    public void Replay()
    {
        GameManager.Instance.Replay();
    }
    IEnumerator Wait2scToDis(float s)
    {
        yield return new WaitForSeconds(s);
        oneMoreTurn.SetActive(true);
    }
    IEnumerator Wait1scToDis(float s)
    {
        yield return new WaitForSeconds(s);
        Replay();
    }
    IEnumerator Wait2scToReplay(float s)
    {
        
        yield return new WaitForSeconds(s);
        oneMoreTurn.SetActive(false);
        StartCoroutine(Wait1scToDis(0.5f));
        
        
    }
    
    
}
