using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerController { get; private set; }

    public Transform player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.PlayerController = player.GetComponent<PlayerController>();

        player.GetChild(GameInfo.Instance.CharacterIndex).gameObject.SetActive(true);
    }
}
