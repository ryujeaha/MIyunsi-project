using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
        public string name;

    [Tooltip("��� ����")]
    public string[] conxext;

    [HideInInspector]
    public string[] VoiceName;
}

[System.Serializable]
public class DialogueEvent
{
    public string name; 

    public Vector2 line;
    public Dialogue[] dialogues;
}