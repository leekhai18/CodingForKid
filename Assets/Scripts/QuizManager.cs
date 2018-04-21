using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : Singleton<QuizManager>
{
    public GameObject quizPannel;

    private Quiz currentQuestion;

    [SerializeField]
    private List<Quiz> listQuizs;

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
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        currentQuestion = listQuizs[0];
        signboard.sprite = currentQuestion.signboard.GetComponent<SpriteRenderer>().sprite;
        question.text = currentQuestion.question;
        answers[0].text = currentQuestion.answers[0];
        answers[1].text = currentQuestion.answers[1];
        answers[2].text = currentQuestion.answers[2];

        if (currentQuestion.correct == 0)
        {
            results[0].text = "CORRECT";
            results[1].text = "FALSE";
            results[2].text = "FALSE";
        }
        else if (currentQuestion.correct == 1)
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

        if (currentQuestion.correct == 0)
            Debug.Log("You have only one more turn!");
        else
            Debug.Log("GAME OVER!");
    }

    public void UserSelectB()
    {
        animator.SetTrigger("B");
        if (currentQuestion.correct == 1)
            Debug.Log("You have only one more turn!");
        else
            Debug.Log("GAME OVER!");
    }
    public void UserSelectC()
    {
        animator.SetTrigger("C");

        if (currentQuestion.correct == 2)
            Debug.Log("You have only one more turn!");
        else
            Debug.Log("GAME OVER!");
    }
}
