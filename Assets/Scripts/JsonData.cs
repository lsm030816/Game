using System;

[Serializable]
public class JsonData
{
    public Conversation[] conversation;
}

[Serializable]
public class Conversation
{
    public string key;
    public string talk;
}


