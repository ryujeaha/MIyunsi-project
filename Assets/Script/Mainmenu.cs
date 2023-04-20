using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject ExitChaek;
    public bool CheakExit = false;
    public bool isPause = false;
    public bool IsSetting = false;
    public GameObject NoSkip;

    public void NOSkip()
    {
        NoSkip.SetActive(true);
    }
    public void NoSkipExit()
    {
        NoSkip.SetActive(false);
    }
 


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (IsSetting == false)
        {
            if (isPause == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }


            if (CheakExit == true)
            {
                ExitChaek.SetActive(true);
            }
            else if (CheakExit == false)
            {
                ExitChaek.SetActive(false);
            }
        }
    }
    public void OnclickYesButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnclickNoButton()
    {
        CheakExit = false;
        isPause = false;
        GameObject.Find("SettingManager").GetComponent<Setting>().OnExit();
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void ClickSettingtbutton()
    {
        IsSetting = true;
    }
    public void Exit()
    {
        IsSetting = false;
    }

    public void OnclickExitButton()
    {
        

        CheakExit = true;
        isPause = true;
        GameObject.Find("SettingManager").GetComponent<Setting>().OnExitButtonClik();
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        
          
    }
}


    




