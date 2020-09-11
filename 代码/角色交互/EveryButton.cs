using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EveryButton : MonoBehaviour
{
    public UIPanel settingpanel;
    public UIPanel StartUIButtonpanel;
    public UIPanel helppanel;
    public void changeLoad()
    {
        SceneManager.LoadScene("Load");
    }
    public void changeSetting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void OpenSetting()
    {
        settingpanel.transform.position = new Vector3(0, 0, 0);
        StartUIButtonpanel.transform.position = new Vector3(-2000, 0, 0);
    }
    public void CloseSetting()
    {
        settingpanel.transform.position = new Vector3(2000, 0, 0);
        StartUIButtonpanel.transform.position = new Vector3(0, 0, 0);
    }
    public void OpenHelp()
    {
        helppanel.transform.position = new Vector3(0, 0, 0);
        StartUIButtonpanel.transform.position = new Vector3(-2000, 0, 0);
    }
    public void CloseHelp()
    {
        helppanel.transform.position = new Vector3(2000, 0, 0);
        StartUIButtonpanel.transform.position = new Vector3(0, 0, 0);
    }
    public void ChangeToExit()
    {
        SceneManager.LoadScene("end");
    }
}
