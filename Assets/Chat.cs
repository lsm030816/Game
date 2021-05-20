using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat : MonoBehaviour
{
    public GameObject chatWindow;
    private Text chatText;
    private void Awake()
    {
        chatText = chatWindow.transform.GetChild(0).GetComponent<Text>();
    }
    public void OpenChat()
    {
        chatWindow.SetActive(true);
    }

    public void CloseChat()
    {
        chatWindow.SetActive(false);
    }

    public void SetText(string text)
    {
        
    }
   
}
