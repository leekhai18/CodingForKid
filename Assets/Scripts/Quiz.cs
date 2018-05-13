using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject signboard;
    [SerializeField]
    private string question = "Đây là biến báo giao thông gì?";
    // public List<string> answers;
    public int correct;

    public string Question
    {
        get
        {
            return question;
        }

        set
        {
            question = value;
        }
    }
}
