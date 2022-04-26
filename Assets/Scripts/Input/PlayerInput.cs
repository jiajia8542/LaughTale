using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInput")]
public class PlayerInput : ScriptableObject, InputActions.IGamePlayActions
{
    InputActions inputActions;
    public bool ClickIsOver => Mouse.current.rightButton.wasReleasedThisFrame;
    public Vector2 CurrentMousePosition => Mouse.current.position.ReadValue();

    public event UnityAction onSetTarget = delegate { };
    public event UnityAction onGetInfo = delegate { };


    void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.GamePlay.SetCallbacks(this);
    }

    void OnDisable()
    {
        DisableAllInput();
    }

    public void DisableAllInput()
    {
        inputActions.GamePlay.Disable();
    }

    public void EnableGamePlayInput()
    {
        inputActions.GamePlay.Enable();
    }
    public void OnSetTarget(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            onSetTarget.Invoke();
        }
    }

    public void OnGetInfo(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            onGetInfo.Invoke();
        }
    }
}

