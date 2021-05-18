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

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);

        if (other.name == "NPC")
        {
            Debug.Log(other.name);
        }
    }
}
