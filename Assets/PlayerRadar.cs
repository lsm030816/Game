using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public LayerMask characterMask;

    private void Awake()
    {
        playerController = transform.parent.GetComponent<PlayerController>();

    }

    private void Start()
    {
        InvokeRepeating("FindTarget", 0.5f, 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Character"))
        {
            playerController.npcList.Add(other.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Character"))
        {
            playerController.npcList.Remove(other.name);
        }

    }


}
