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



    private void OnTriggerEnter(Collider other)
    {

        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Character"))
        {
            string[] types = other.gameObject.name.Split('_');
            switch (types[0])
            {
                case "NPC":
                    playerController.FindNPC(other.name);
                    break;
                default:
                    break;
            }
        
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Character"))
        {
            string[] types = other.gameObject.name.Split('_');
            switch (types[0])
            {
                case "NPC":
                    playerController.RemoveNPC(other.name);
                    break;
                default:
                    break;
            }
        }

    }


}
