using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject choice;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;
    public Animator anim;
    public bool testbool;
    private void Start()
    {
        Settingweb(false);
    }
    public void ShowSelection()
    {
        Settingweb(true);
        Time.timeScale = 0f;
        anim.SetBool("Appear", true);
    }

    public void Onanswer1()
    {

        Settingweb(false);
        answer1.GetComponent<BlackOut>().OnCLick();
    
       
    }

    public void Onanswer2()
    {

        Settingweb(false);
        answer2.GetComponent<BlackOut>().OnCLick();
     
       
    }
    public void Onanswer3()
    {

        Settingweb(false);
        answer3.GetComponent<BlackOut>().OnCLick();
       
        
    }

 private void Settingweb(bool P_fleg)
    {
        choice.SetActive(P_fleg);
    }

}
