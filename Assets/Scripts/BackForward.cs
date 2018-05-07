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
        velocity = 1000;
        containerEnd = GameManager.Instance.containerEnd;
    }

    // Update is called once per frame
    void Update()
    {
        // ContainerEnd will move from 358 to -1020
        if (isDowning)
        {
            if (isBackward)
            {
                if (containerEnd.transform.position.x > -1020)
                {
                    GameManager.Instance.Backward(velocity * Time.deltaTime, 0.2f);
                }
            }
            else
            {
                if (containerEnd.transform.position.x < 358)
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
