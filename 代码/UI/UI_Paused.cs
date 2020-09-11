using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Paused : MonoBehaviour
{
    public GameObject Pause;
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        pause= Input.GetKeyDown(KeyCode.Escape);
        if (pause == true)
        {
            Pause.gameObject.SetActive(true);
        }
    }
    public void OnClickContinue()
    {
        Pause.gameObject.SetActive(false);
    }
    public void OnClickReturn()
    {
        SceneManager.LoadScene("beginUI");
    }
    public void OnClickQuit()
    {
        SceneManager.LoadScene("end");
    }
}
