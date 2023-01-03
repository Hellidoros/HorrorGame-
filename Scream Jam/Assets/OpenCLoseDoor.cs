using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCLoseDoor : MonoBehaviour
{
    [SerializeField] Animator animator;
    private bool canOpen = true;
    public bool opened = true;


    private IEnumerator Countdown()
    {
        float duration = 1f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        canOpen = true;
    }

    public void Open()
    {
        if (canOpen)
        {
            canOpen = false;
            if (opened == false)
            {
                opened = true;
                animator.GetComponent<Animator>().Play("Open", -1, 0f);
                StartCoroutine(Countdown());
            }
            else
            {
                opened = false;
                animator.GetComponent<Animator>().Play("Close", -1, 0f);
                StartCoroutine(Countdown());
            }
        }
    }
}
