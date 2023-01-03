using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] PlayableDirector playableDirector;
    private bool canCLick = true;


    private void OnTriggerEnter(Collider other)
    {
        if (canCLick)
        {
            canCLick = false;
            if (other.gameObject.CompareTag("Player"))
            {
                wall.SetActive(true);
                playableDirector.Play();
            }
        }
    }
}
