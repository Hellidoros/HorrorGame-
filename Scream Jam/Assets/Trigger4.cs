using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger4 : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wall.SetActive(true);
        }
    }
}
