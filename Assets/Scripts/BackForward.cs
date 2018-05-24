using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BackForward : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject containerEnd;

    [SerializeField]
    bool isBackward;

    bool isDowning;

    float velocity;

    // Use this for initialization
    void Start()
    {
        velocity = 2000;
        containerEnd = GameManager.Instance.containerEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDowning)
        {
            if (isBackward)
            {
                if (containerEnd.transform.localPosition.x > -1202)
                {
                    GameManager.Instance.Backward(velocity * Time.deltaTime, 0.2f);
                }
            }
            else
            {
                if (containerEnd.transform.localPosition.x < -6)
                {
                   GameManager.Instance.Forward(velocity * Time.deltaTime, 0.2f);
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDowning = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDowning = false;
    }
}
