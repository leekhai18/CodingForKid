using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : Singleton<QuizManager>
{
    public GameObject quizPannel;
    public GameObject quizBackground;
    private Quiz currentQuiz;

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

    private void Start()
    {
    }

    public void InitQuiz(Quiz quiz)
    {
        SetCurrentQuiz(quiz);
        animator.SetTrigger("Refresh");
        quizPannel.SetActive(true);
        quizBackground.SetActive(true);
    }

    public void SetCurrentQuiz(Quiz quiz)
    {
        
        currentQuiz = quiz;


        Item item = ItemDataBase.GetItem(currentQuiz.GetComponent<Quiz>().signboard.GetComponent<IDcontroller>().ID);
        // signboard.sprite = currentQuiz.signboard.GetComponent<SpriteRenderer>().sprite;
        signboard.sprite = item.iconSprite;
        question.text = currentQuiz.question;
        answers[0].text = currentQuiz.answers[0];
        answers[1].text = currentQuiz.answers[1];
        answers[2].text = currentQuiz.answers[2];

        if (currentQuiz.correct == 0)
        {
            results[0].text = "CORRECT";
            results[1].text = "FALSE";
            results[2].text = "FALSE";
        }
        else if (currentQuiz.correct == 1)
        {
            results[0].text = "FALSE";
            results[1].text = "CORRECT";
            results[2].text = "FALSE";
        }
        else
        {
            results[0].text = "FALSE";
            results[1].text = "FALSE";
            results[2].text = "CORRECT";
        }

    }

    public void UserSelectA()
    {
        animator.SetTrigger("A");

        if (currentQuiz.correct == 0)
        {
            Debug.Log("You have only one more turn!");
        }
        else
            Debug.Log("GAME OVER!");
    }

    public void UserSelectB()
    {
        animator.SetTrigger("B");
        if (currentQuiz.correct == 1)
            Debug.Log("You have only one more turn!");
        else
            Debug.Log("GAME OVER!");
        }
    public void UserSelectC()
    {
        animator.SetTrigger("C");

        if (currentQuiz.correct == 2)
            Debug.Log("You have only one more turn!");
        else
            Debug.Log("GAME OVER!");
        
    }
}
