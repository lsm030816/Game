using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager : MonoBehaviour
{
    [SerializeField] private string streaminAssetsPath;
    string jsonText;

    private void Start()
    {
        streaminAssetsPath = Path.Combine(Application.streamingAssetsPath, "gameData.json");
        StartCoroutine(LoadJson());
    }

    IEnumerator LoadJson()
    {
        jsonText = string.Empty;
   

        if (File.Exists(streaminAssetsPath))
        {
            jsonText = File.ReadAllText(streaminAssetsPath);
            GameInfo.Instance.jsonData = JsonUtility.FromJson<JsonData>(jsonText);
        }

        yield return null;
    }

}
