using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        this.PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}
