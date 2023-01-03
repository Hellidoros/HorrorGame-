using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButtonScript : MonoBehaviour
{
    [SerializeField] Text texts;
    [SerializeField] Text lowerText;
    [SerializeField] GameObject[] strangers;
    [SerializeField] Animator animator;
    [SerializeField] Transform[] heads;
    [SerializeField] Transform player;

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

    private void Update()
    {
        if (num == 5)
        {
            strangers[0].SetActive(true);
            lowerText.text = "Don't look back";
            lowerText.color = new Color(1, 0, 0);
        }

        if (num == 10)
        {
            strangers[1].SetActive(true);
            lowerText.text = "Don't look back!";
            foreach (Transform head in heads)
            {
                head.LookAt(player);
            }
        }

        if (num == 15)
        {
            canClick = false;
            texts.text = "LOOK BACK";
            texts.color = new Color(1, 0, 0);
            strangers[2].SetActive(true);
            lowerText.text = "";
            lowerText.color = new Color(171, 171, 171);
        }

        if (num == 16)
        {
            texts.text = "16/50";
            texts.color = new Color(0, 1, 0);
            strangers[2].SetActive(true);
            lowerText.text = "press green button";
            lowerText.color = new Color(171, 171, 171);
        }

        if (num == 30)
        {
            strangers[3].SetActive(true);
            lowerText.text = "Look back";
            lowerText.color = new Color(1, 0, 0);
        }

        if (num == 40)
        {
            canClick = false;
            texts.text = "LOOK BACK";
            texts.color = new Color(1, 0, 0);
            strangers[2].SetActive(true);
            lowerText.text = "";
            lowerText.color = new Color(171, 171, 171);
        }

        if (num == 41)
        {
            texts.text = "41/50";
            texts.color = new Color(0, 1, 0);
            strangers[2].SetActive(true);
            lowerText.text = "press green button";
            lowerText.color = new Color(171, 171, 171);
        }

        if (num == 50)
        {
            texts.text = "LOOK BACK";
            lowerText.text = "back";
            lowerText.color = new Color(1, 0, 0);

            foreach (GameObject obj in strangers)
            {
                obj.SetActive(false);
            }
        }
    }

}
