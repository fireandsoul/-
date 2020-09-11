using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject talkUI;
    public GameObject Button;
     // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if( Button.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
           //print("!!!");
        }
    }

   void OnCollisionEnter(Collision other)
    {
        //if (other.collider.tag == "Player")
      // print("...");
        Button.SetActive(true);
        //}

    }
    void OnCollisionExit(Collision other)
    {
         Button.SetActive(false);
        //print("1111");
    }
}
