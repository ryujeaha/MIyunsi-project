using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] string csv_FilName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    public static bool isFinish = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DialoguePaser thePaser = GetComponent<DialoguePaser>();
            Dialogue[] dialogues = thePaser.Parse(csv_FilName);
            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;    
        }
    }
    public Dialogue[] GetDialogues(int _StartNum, int _Endnum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for(int i =0; i <= _Endnum - _StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }

        return dialogueList.ToArray();
    }
}
