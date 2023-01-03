using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumscare : MonoBehaviour
{
    [SerializeField] private GameObject jumpScare;
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject oldphone;
    [SerializeField] private GameObject phone;

    private bool scared = true;

    private IEnumerator Countdown()
    {
        float duration = 2.5f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        jumpScare.SetActive(false);
        background.SetActive(false);
        monster.SetActive(false);
        button.SetActive(false);
        endCanvas.SetActive(true);
        StartCoroutine(Countdown2());
    }

    private IEnumerator Countdown2()
    {
        float duration = 4f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        endCanvas.SetActive(false);
        oldphone.SetActive(false);
        phone.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scared)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                scared = false;
                jumpScare.SetActive(true);
                background.SetActive(true);
                StartCoroutine(Countdown());
            }
        }
    }


}
