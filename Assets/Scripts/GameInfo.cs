using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : GenericSingleton<GameInfo>
{
    public int CharacterIndex { get; set; }

    public JsonData jsonData;
}
