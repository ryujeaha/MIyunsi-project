using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkStart : MonoBehaviour
{

    DialogueManager theDM;  

    
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theDM.ShowDialogue(GetComponent<interationEvent>().GetDialogues());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
