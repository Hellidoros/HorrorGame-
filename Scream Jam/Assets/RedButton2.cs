using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject oldHead;
    [SerializeField] private GameObject[] buttons;
    [Space]
    [SerializeField] private GameObject oldMonster;
    [SerializeField] private GameObject monster;
    [SerializeField] Animator animator;
    [SerializeField] GameObject canvas;

    private bool canClick = true;
    private int count = 1;
    public int pressedCount = 0;


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

    private IEnumerator Countdown2()
    {
        float duration = 5f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }

        canvas.SetActive(false);
        monster.SetActive(true);
        oldMonster.SetActive(false);
    }

    private void Timer()
    {
        canClick = false;
        StartCoroutine(Countdown());
    }


    public void ButtonPressed()
    {
        if (canClick && count == 1)
        {
            count += 1;
            animator.GetComponent<Animator>().Play("ButtonAnim", -1, 0f);
            Timer();
            head.SetActive(true);
            oldHead.SetActive(false);
        }
        if (canClick && count >= 2)
        {
            count += 1;
            animator.GetComponent<Animator>().Play("ButtonAnim", -1, 0f);

            canvas.SetActive(true);
            StartCoroutine(Countdown2());
        }
    }

    private void Update()
    {
        head.transform.LookAt(player);

        if (pressedCount == 3)
        {
            Application.LoadLevel("Scene4");
        }
    }

    
}
