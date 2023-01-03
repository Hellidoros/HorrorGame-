using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedButton : MonoBehaviour
{ 
    [SerializeField] Animator animator;
    [SerializeField] AudioSource sound;
    [SerializeField] GameObject button;
    [SerializeField] Transform[] heads;
    [Space]
    [SerializeField] Transform player;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioSource sound2;

    public int num;
    public bool canClick = true;
    private bool look;

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

        sound2.Play();
        canvas.SetActive(true);
        StartCoroutine(Countdown2());
    }

    private IEnumerator Countdown2()
    {
        float duration = 1.5f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        canvas.SetActive(false);
        monster.SetActive(true);
    }


    public void AddCount()
    {
        if (canClick == true)
        {
            animator.GetComponent<Animator>().Play("ButtonAnim", -1, 0f);
            sound.Play();
            canClick = false;
            look = true;

            foreach ( Transform head in heads)
            {
                head.LookAt(player);
            }
            StartCoroutine(Countdown());
        }
    }

    private void Update()
    {
        if (look)
        {
            foreach (Transform head in heads)
            {
                head.LookAt(player);
            }
        }
    }
}
