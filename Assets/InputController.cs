using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    PlayerInputAction playerInputAction;
    [SerializeField] private GameManager gameManager;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();

        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.SetCallbacks(this);
    }

    void OnEnable()
    {
        playerInputAction.Player.Enable();
    }

    void OnDisable()
    {
        playerInputAction.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 axis = context.ReadValue<Vector2>();

        if (context.performed)
        {
            gameManager.PlayerController.StopCoroutine("Move");
            gameManager.PlayerController.StartCoroutine("Move", axis);
        }

        if (context.canceled)
        {
            gameManager.PlayerController.StopCoroutine("Move");
        }
    }
}
