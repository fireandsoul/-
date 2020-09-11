using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    [Header("======KeyCode ======")]
    public string Keyup;
    public string Keydown;
    public string Keyright;
    public string Keyleft;

    public string KeyA;
    public string KeyB;
    public string KeyC;
    public string KeyD;

    public string KeyJup;
    public string KeyJdown;
    public string KeyJright;
    public string KeyJleft;

    public string KeyEsc;



    [Header("====== Signal ======")]
    public float Dup;
    public float Dright;

    public float Jup;
    public float Jright;

    public float Dmsg;
    public Vector3 Dvec;
    public bool run;
    public bool jump;
    private bool lastJump;
    public bool attack;
    private bool lastAttack;
    public bool inputEnabled = true;
    public bool escEnable;

    [Header("=====Mouse settings =====")]
    public bool mouseEnabled = true;
    public float mouseSensitivityX = 1.0f;
    public float mouseSensitivityY = 1.0f;


    [Header("====other ====")]
    private float targetUp;
    private float targetRight;
    private float velocityUp;
    private float velocityRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  if(mouseEnabled == true)
        {
            Jup = Input.GetAxis("Mouse Y") * 0.5f * mouseSensitivityX;
            Jright = Input.GetAxis("Mouse X") * 1.0f * mouseSensitivityY;
        }
        if (mouseEnabled == false)
        {
            Jup = (Input.GetKey(KeyJup) ? 1.0f : 0) - (Input.GetKey(KeyJdown) ? 1.0f : 0);
            Jright = (Input.GetKey(KeyJright) ? 1.0f : 0) - (Input.GetKey(KeyJleft) ? 1.0f : 0);
        }
       

        targetUp = (Input.GetKey(Keyup) ? 1.0f : 0) - (Input.GetKey(Keydown) ? 1.0f : 0);
        targetRight = (Input.GetKey(Keyright) ? 1.0f : 0) - (Input.GetKey(Keyleft) ? 1.0f : 0);
        if(inputEnabled == false)
        {
            targetUp = 0;
            targetRight = 0;
        }
        Dup = Mathf.SmoothDamp(Dup, targetUp, ref velocityUp, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetRight, ref velocityRight,0.1f);
       //解决斜向运动产生的问题
        Vector2 tempAxis = SquareToCircle(new Vector2(Dright, Dup)); 
        float Dright2 = tempAxis.x;
        float Dup2 = tempAxis.y;

        Dmsg = Mathf.Sqrt(Dup2 * Dup2 + Dright2 * Dright2);
        Dvec = transform.forward * Dup2 + transform.right * Dright2;
        
        run = Input.GetKey(KeyA);
        jump = Input.GetKey(KeyB);
        attack = Input.GetKey(KeyC);
        escEnable = Input.GetKey(KeyEsc);
        bool newJump = jump;
        if(newJump != lastJump && newJump ==true)
        {
            jump = true;
          
        }
        else
        {
            jump = false;
           
        }
        lastJump = newJump;

        bool newAttack = attack;
        if (newAttack != lastAttack && newAttack == true)
        {
            attack = true;

        }
        else
        {
            attack = false;

        }
        lastAttack = newAttack;

        //if(escEnable == true)
        //{
        //    mouseEnabled = false;
        //    SceneManager.LoadScene("Setting");
        //}
    }
    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;


        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x)/ 2.0f);

        return output;
    }



}

