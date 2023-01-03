using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask = 8;
    public Interactable interactable;
    UnityEvent onInteract;
    public Image interactImage;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Vector2 defaultInteractorSize;
    public Sprite defaultInteractIcon;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    Debug.Log("New interactable");
                }
                if (interactable.interactableIcon != null)
                {
                    interactImage.sprite = interactable.interactableIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractorSize;
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractorSize;
                }

                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
                {
                    interactable.onInteract.Invoke();
                }
            }
        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}
