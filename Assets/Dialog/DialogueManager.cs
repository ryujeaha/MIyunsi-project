using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    public GameObject CG;
    public GameObject blackout;
    public GameObject ST;
 
    Dialogue[] dialogues;

    bool SSS = true;
    bool isDialogue = false;
    bool isNext = false; //특정 키 입력 대기.

    [Header("텍스트 출력 딜레이.")]
    [SerializeField] float textDelay;
    int lineCount = 0;//대화 카운트
    int contextCount = 0; //대사 카운트

    

     void Start()
    {   
         
    }

    void Update()
    {
        if (isDialogue)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                SSS = false;
                if(SSS == false)
                {
                    textDelay = 0f;

                }
                

                
                
                    

                
                
            }
            if (dialogues[lineCount].name == "선택지")
            {

                go_DialogueBar.SetActive(false);
                ST.GetComponent<Test>().ShowSelection();

            }
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
                {
                    textDelay = 0.07f;
                    SSS = true;
                    
                    isNext = false;
                    txt_Dialogue.text = "";
                    if(++contextCount < dialogues[lineCount].conxext.Length)
                    {
                        StartCoroutine(TypeWriter());
                        
                    }
                    else
                    {
                        contextCount = 0;
                        if(++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                            CG.GetComponent<StandingCG>().NextCG();
                        }
                        else
                        {
                            EndDialogue();
                           
                        }
                    }
                    
                }
              
            }
        }
        
    }

    public void ShowDialogue(Dialogue[] P_dialogues) 
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = P_dialogues;

        StartCoroutine(TypeWriter()); 
       
    }
    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUi(false);
        blackout.GetComponent<BlackOut>().OnCLick();
    }
    void PlaySound()
    {
        if(dialogues[lineCount].VoiceName[contextCount] != "")
        {
            SoundManager.instance.PlaySound(dialogues[lineCount].VoiceName[contextCount], 2);
        }
    }

    IEnumerator TypeWriter()
    {
        SettingUi(true);
        PlaySound();
        string t_ReplaceText = dialogues[lineCount].conxext[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        t_ReplaceText = t_ReplaceText.Replace("\\n","\n");
      

        

        bool t_black = false, t_yellow = false;
        bool t_ignore = false;

        for(int i = 0; i < t_ReplaceText.Length; i++)
        {
            switch(t_ReplaceText[i])
            {
                case 'ⓑ': t_black = true; t_yellow = false; t_ignore = true; break;
                case 'ⓨ': t_black = false; t_yellow = true; t_ignore = true; break;
                case 'ⓓ':SoundManager.instance.PlaySound("door", 1); t_ignore = true; break;
                case '①':SoundManager.instance.PlaySound("Emotion1", 1); t_ignore = true; break;
                case 'ⓟ': SoundManager.instance.PlaySound("Put down", 1); t_ignore = true; break;
                case '②': SoundManager.instance.PlaySound("gg", 1); t_ignore = true; break;
                case '③': SoundManager.instance.PlaySound("Cafe", 1); t_ignore = true; break;
                case '④': SoundManager.instance.PlaySound("!!", 1); t_ignore = true; break;
                case '⑤': SoundManager.instance.PlaySound("Pon", 1); t_ignore = true; break;
               case '⑥': SoundManager.instance.PlaySound("Phone", 1); t_ignore = true; break;
                case '⑦': SoundManager.instance.PlaySound("SSG", 1); t_ignore = true; break;
                case 'ⓦ': SoundManager.instance.PlaySound("Walk", 1); t_ignore = true; break;
            }

            string t_letter = t_ReplaceText[i].ToString();

            if (!t_ignore)
            {

                if (t_black) { t_letter = "<color=#000000>" + t_letter + "</color>"; }
                else if (t_yellow){ t_letter = "<color=#FFFF00>" + t_letter + "</color>"; }
                txt_Dialogue.text += t_letter;
            }
            t_ignore = false;

           
            yield return new WaitForSeconds(textDelay);
        }

        isNext = true;
       
    }
    void SettingUi(bool P_fleg)
    {
        go_DialogueBar.SetActive(P_fleg);
        go_DialogueNameBar.SetActive(P_fleg);


        if (P_fleg)
        {
            if(dialogues[lineCount].name == "" || dialogues[lineCount].name == "선택지")
            {
                go_DialogueNameBar.SetActive(false);
            }
            else
            {
                go_DialogueNameBar.SetActive(true);
                txt_Name.text = dialogues[lineCount].name;
            }
            
        }

       
    }
}
