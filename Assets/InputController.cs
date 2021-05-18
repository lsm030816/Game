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

        if (context.started)
        {
            return;
        }

        Vector2 axis = context.ReadValue<Vector2>();
        gameManager.PlayerController.SetAxis(axis);

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            gameManager.PlayerController.TryJump();
        }
    }
}
