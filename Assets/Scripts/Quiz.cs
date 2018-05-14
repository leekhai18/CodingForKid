using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject signboard;
    [SerializeField]
    public string Question = "Đây là biến báo giao thông gì?";
    // public List<string> answers;
    public int correct;
    public Quiz()
    {

    }
    public Quiz(Quiz q)
    {
        Question = q.Question;
        correct = q.correct;
        signboard = q.signboard;
    }
}
