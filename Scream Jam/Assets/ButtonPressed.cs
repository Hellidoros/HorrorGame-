using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField] GameObject RedButton;
    public bool canCLick = true;
    [SerializeField] Animator animator;

    private IEnumerator Countdown()
    {
        float duration = 1f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        Destroy(this.gameObject);
    }

    public void Press()
    {
        if (canCLick)
        {
            canCLick = false;
            animator.GetComponent<Animator>().Play("ButtonAnim", -1, 0f);
            RedButton.GetComponent<RedButton2>().pressedCount += 1;
            StartCoroutine(Countdown());
        }
    }
}
