using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBackScript : MonoBehaviour
{
    [SerializeField] GameObject buttonScript;
    [SerializeField] GameObject endScene;
    [SerializeField] AudioSource scary;
    [SerializeField] Transform player;


    private IEnumerator Countdown()
    {
        float duration = 5f; // 3 seconds you can change this 
                               //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        endScene.SetActive(true);
        scary.Play();
        MovePlayerPosition();
        StartCoroutine(Countdown2());
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

        endScene.SetActive(false);
        player.gameObject.GetComponent<PlayerMovement>().enabled = true;
    }


    public void MovePlayerPosition()
    {
        player.position = new Vector3(0.709f, 1.094f, 5.449f);
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            buttonScript.GetComponent<GreenButtonScript>().StopAllCoroutines();
            buttonScript.GetComponent<GreenButtonScript>().num += 1;
            buttonScript.GetComponent<GreenButtonScript>().canClick = true;

            if (buttonScript.GetComponent<GreenButtonScript>().num >= 50)
            {
                StartCoroutine(Countdown());
            }
        }
    }
}
