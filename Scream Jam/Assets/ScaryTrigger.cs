using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ScaryTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private PlayableDirector playableDirector;
    private bool scared = true;

    private void OnTriggerEnter(Collider other)
    {
        if (scared)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                scared = false;
                playableDirector.Play();
                sound.Play();
            }
        }
    }
}
