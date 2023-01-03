using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare3 : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject oldmosnter;

    private IEnumerator Countdown()
    {
        float duration = 20f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        monster.SetActive(true);
        oldmosnter.SetActive(false);
    }


    public void ActivateMonster()
    {
        StartCoroutine(Countdown());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivateMonster();
        }
    }
}
