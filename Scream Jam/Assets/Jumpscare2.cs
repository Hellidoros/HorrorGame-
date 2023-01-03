using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare2 : MonoBehaviour
{
    [SerializeField] private GameObject[] monster;
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private GameObject canvas;

    private IEnumerator Countdown()
    {
        float duration = 3f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        Application.LoadLevel(Application.loadedLevel);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            jumpscare.SetActive(true);
            canvas.SetActive(true);

            foreach (GameObject parts in monster)
            {
                parts.SetActive(false);
            }

            StartCoroutine(Countdown());
        }
    }
}
