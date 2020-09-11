using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public float walkspeed = 2.4f;
    public float runMultispeed = 2.0f;
    public float jumpMulti = 5.0f;
    public float rollvelocity = 3.0f;
    public float jabvelocity = 3.0f;
    public float attackvelocity;

    public GameObject model;


    private PlayerInput pi;
    [SerializeField]
    private Animator anim;
    private Rigidbody rig;

    private Vector3 PlaneVec;
    private Vector3 thrustVec;
    private bool canAttack = true;

    [SerializeField]
    private bool lockPlane = false;

   


    // Start is called before the first frame update
    void Awake()
    {
        anim = model.GetComponent<Animator>();
        pi = GetComponent<PlayerInput>();
        rig = GetComponent<Rigidbody>();

       Cursor.lockState = CursorLockMode.Confined;//鼠标在开始就消失
    }

    // Update is called once per frame
    void Update()
    {
       
        

        anim.SetFloat("forward", pi.Dmsg * Mathf.Lerp(anim.GetFloat("forward"), ((pi.run) ? 2.0f : 1.0f), 0.5f));
        //if(rig.velocity.magnitude >0f)
        //{
        //    anim.SetTrigger("roll");
        //}
        if (pi.jump == true)
        {
            anim.SetTrigger("jump");
            canAttack = false;
        }
        if (pi.attack && CheckState("ground") && canAttack ==true)
        {
            anim.SetTrigger("attack");
        }
        if (pi.Dmsg > 0.1f)//解决人物转向问题
        {

            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.3f);
        }

        if (lockPlane == false)
        {
            PlaneVec = pi.Dmsg * model.transform.forward * (walkspeed * ((pi.run) ? runMultispeed : 1.0f));
        }





    }
    private void FixedUpdate()
    {


        // rig.transform.position += movingVec * Time.fixedDeltaTime;
        rig.velocity = new Vector3(PlaneVec.x, rig.velocity.y, PlaneVec.z) + thrustVec;
        thrustVec = Vector3.zero;

      

    }

    private bool CheckState(string stateName , string layerName = "Base Layer")
    {
        //int layerIndex = anim.GetLayerIndex(layerName);
        //bool result = anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(layerName)).IsName(stateName);
        return  anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex(layerName)).IsName(stateName);
    }


    /// 
    /// Message processing block
    /// 
    public void EnterJump()
    {
        thrustVec = new Vector3(0, jumpMulti, 0);
        pi.inputEnabled = false;
        lockPlane = true;
     

    }


    public void IsGround()
    {

        anim.SetBool("isGround", true);
    }
    public void IsNotGround()
    {

        anim.SetBool("isGround", false);
    }
    public void OnGroundEnter()
    {
        pi.inputEnabled = true;

        lockPlane = false;
        canAttack = true;
    }

    public void OnFallEnter()
    {
        pi.inputEnabled = false;
        lockPlane = true;
    }
    public void OnAttack_Rh_Enter()
    {
        pi.inputEnabled = false;
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 1.0f);
    }

    public void OnAttack_Rh_Update()
    {
        thrustVec = model.transform.forward * anim.GetFloat("attackvelocity");
    }
    public void OnAttack_Idel_Enter()
    {
        pi.inputEnabled = true;
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 0);
    }







    //public void OnRollEnter()
    //{ 
    //    Jumpvec = new Vector3(0, rollvelocity, 0);
    //    pi.inputEnabled = false;
    //    lockPlane = true;

    //}

    //public void OnJabEnter()
    //{
    //    pi.inputEnabled = false;
    //    lockPlane = true;    
    //}
    //public void OnJabUpdate()
    //{
    //    Jumpvec = model.transform.forward * anim.GetFloat("jabvelocity");
    //}


}
