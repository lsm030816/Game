using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Chat chat;

    public Transform startPoint;
    public GameObject playerPrefab;
    public PlayerController PlayerController { get; private set; }

    public GameObject npcPrefab;
    private Dictionary<string, NpcController> npcControllers;

    HashSet<int> randomNum;

    private void Awake()
    {
        chat = GetComponent<Chat>();

        randomNum = new HashSet<int>();
        npcControllers = new Dictionary<string, NpcController>();

        GameObject player = Instantiate(playerPrefab, startPoint.position, startPoint.rotation);
        this.PlayerController = player.GetComponent<PlayerController>();
        this.PlayerController.gameManager = this;

        player.transform.GetChild(GameInfo.Instance.CharacterIndex).gameObject.SetActive(true);

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            GameObject npc = Instantiate(npcPrefab, child.position, child.rotation);
            NpcController npcController = npc.GetComponent<NpcController>();
            
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, 60);
            }
            while (randomNum.Contains(randomIndex));

            randomNum.Add(randomIndex);

            Transform childObj = npc.transform.GetChild(randomIndex);
            childObj.gameObject.SetActive(true);
            string[] words = childObj.name.Split('_');
            npc.name = $"NPC_{words[2]}{words[3]}";

            npcControllers.Add(npc.name, npcController);
        }
    }

    public void ConnectNPC(string npcName)
    {
        if (npcControllers.ContainsKey(npcName))
        {
            npcControllers[npcName].GoTalk();
            chat.OpenChat();
            JsonData jsonData  = GameInfo.Instance.jsonData;
            chat.SetText(jsonData.conversation[0].talk);
        }

    }

    public void DisconnectNPC(string npcName)
    {
        npcControllers[npcName].StopTalk();
        chat.CloseChat();
    }
}
