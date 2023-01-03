using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene2 : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private IEnumerator Countdown()
    {
        float duration = 4f; // 3 seconds you can change this 
                              //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        Application.LoadLevel("Scene3");
    }



    public void StartTimeline()
    {
        canvas.SetActive(true);
        StartCoroutine(Countdown());
    }
}
