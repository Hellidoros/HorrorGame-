using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCanvasScript : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

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
        Destroy(this.gameObject);
        sound.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

}
