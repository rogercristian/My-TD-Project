using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 rotateDirection = Vector2.zero;
    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool startPressed = false;
    private bool selectPressed = false;
    float scroll;
    private static InputManager instance;

    private void Awake()
    {
        if(instance != null) {
            Debug.LogError("Mais de um input manager achado na cena");
        }
        instance = this;
    }
   
    public static InputManager GetInstance()
    {
        return instance;
    }

    // configurando os botoes
        // move char
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }            
    }

    public void ScroolAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            scroll = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            scroll = context.ReadValue<float>();
        }
    }

    public void RotatePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rotateDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            rotateDirection= context.ReadValue<Vector2>();
        }
    }
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
   
   public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    public void StartButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            startPressed = true;
        }
        else if (context.canceled)
        {
            startPressed = false;
        }
    }

    public void SelectButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            selectPressed = true;
        }
        else if (context.canceled)
        {
            selectPressed = false;
        }
    }
    // 
    public Vector2 GetMoveDirection() { return moveDirection; }
    public float GetScrollAction() { return scroll; }
    public Vector2 GetRotatieDirection() { return rotateDirection; }
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        submitPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public bool GetStartPressed()
    {
        bool result = startPressed;
        startPressed = false;
        return result;
    }
    public bool GetSelectPressed()
    {
        bool result = selectPressed;
        selectPressed = false;
        return result;
    }
    public void RegisterSubmitPressed()
    {
        submitPressed = false;
    }
}
