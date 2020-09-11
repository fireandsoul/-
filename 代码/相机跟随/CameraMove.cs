using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float time = 3.0f;
   public void DestroyCamera()
    {
       gameObject.SetActive(false);
    }
   
}
