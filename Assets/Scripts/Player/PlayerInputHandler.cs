using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action OnJumpButtonDown;
    public event Action OnJumpButtonUp;
    public event Action OnEKeyDown;
    public event Action OnLBMPressed;
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpButtonDown?.Invoke();
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            OnJumpButtonUp?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnEKeyDown?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            OnLBMPressed?.Invoke();
        }
    }
}