using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public bool SettingScreen = false;
    public GameObject setting;
    public bool isPause = false;
    public bool isExit = false;
    // Start is called before the first frame update
    public void SettingClick()
    {
        isPause = true;
        SettingScreen = true;

        GameObject.Find("Exitmanager").GetComponent<Mainmenu>().ClickSettingtbutton();

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void ExitClick()
    {
        SettingScreen = false;
        isPause = false;
        GameObject.Find("Exitmanager").GetComponent<Mainmenu>().Exit();
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void OnExitButtonClik()
    {
        isExit = true;
        
    }
    public void OnExit()
    {
        isExit = false;
    }

    private void Update()
    {
        if (isExit == false)
        {
            if (isPause == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            if (SettingScreen == true)
            {

                setting.SetActive(true);
            }
            else if (SettingScreen == false)
            {
                setting.SetActive(false);
            }
        }
    }
}
