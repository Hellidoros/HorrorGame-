using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float xRotation = 0f;
    private bool canMoveMouse = true;

    [SerializeField] private float _mouseSensivity = 100f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private GameObject _dialogueManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChagneCursorlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void changeMouseState()
    {
        canMoveMouse = !canMoveMouse;
    }



    void Update()
    {
        if (canMoveMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
