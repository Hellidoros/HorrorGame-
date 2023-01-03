using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewButtonScript : MonoBehaviour
{
    [SerializeField] Text texts;
    [SerializeField] Text lowerText;
    [SerializeField] GameObject[] strangers;
    [SerializeField] Animator animator;

    public int num;
    public bool canClick = true;

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
        canClick = true;
    }

    private void Start()
    {
        animator.GetComponent<Animator>().Play("New Animation", -1, 0f);
    }

    private void Timer()
    {
        canClick = false;
        StartCoroutine(Countdown());
    }


    public void AddCount()
    {
        if (canClick == true)
        {
            animator.GetComponent<Animator>().Play("ButtonAnim", -1, 0f);
            Timer();
            if (num < 50)
            {
                num += 1;
                texts.text = num.ToString() + " /50";
            }
        }
    }
}
