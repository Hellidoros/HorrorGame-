using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Script : MonoBehaviour
{
    [SerializeField] Transform player;

    private IEnumerator Countdown(int num)
    {
        float duration = num; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }

    public void MovePlayerPosition()
    {
        player.position = new Vector3(-2.67f, 1.248f, -14.605f);
        player.transform.eulerAngles = new Vector3(0f,95f,0f);
    }

}
