using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public PlayerInput pi;
    public float horizontalSpeed = 100.0f;
    public float vertical =45.0f;
    public float cameraDampValue = 0.5f;

    private GameObject playerHandle;
    private GameObject cameraHandle;
    private GameObject model;
    public  new GameObject  camera;

    private float tempEulerX;
    private Vector3 cameraDampVelocity;
    void Awake()
    {
       cameraHandle = transform.parent.gameObject;
       playerHandle = cameraHandle.transform.parent.gameObject;
       model = playerHandle.GetComponent<ActionController>().model;
       camera = Camera.main.gameObject;
       tempEulerX = 20;
    }
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Linecast(model.transform.position + Vector3.up, camera.transform.position, out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                //如果射线碰撞的不是相机，那么就取得射线碰撞点到玩家的距离
                float currentDistance = Vector3.Distance(hit.point, model.transform.position);
                float distance = Vector3.Distance(model.transform.position, camera.transform.position);
                //如果射线碰撞点小于玩家与相机本来的距离，就说明角色身后是有东西，为了避免穿墙，就把相机拉近
                if (currentDistance < distance)
                {
                    camera.transform.position = hit.point;
                }
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tempModelEuler = model.transform.eulerAngles; 
        playerHandle.transform.Rotate(Vector3.up,pi.Jright * horizontalSpeed * Time.fixedDeltaTime);
        //欧拉角问题
        tempEulerX -= pi.Jup * vertical * Time.fixedDeltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -30, 30);
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

         model.transform.eulerAngles = tempModelEuler;

        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, transform.position, ref cameraDampVelocity, cameraDampValue);
        camera.transform.eulerAngles = transform.eulerAngles;
    }
}
