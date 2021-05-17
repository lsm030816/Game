using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerController { get; private set; }

    public Transform startPoint;
    public GameObject playerPrefab;


    private void Awake()
    {
        GameObject obj = Instantiate(playerPrefab, startPoint.position, startPoint.rotation);
        this.PlayerController = obj.GetComponent<PlayerController>();

        obj.transform.GetChild(GameInfo.Instance.CharacterIndex).gameObject.SetActive(true);
    }
}
