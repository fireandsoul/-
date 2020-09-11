using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SphereMove : MonoBehaviour
{
    public GameObject model;
    public Animation anim;
    public NavMeshAgent agent;

    private bool IsMove = false;

   
    
    void Start()
    {
        anim = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(IsMove == true)
        {
            agent.SetDestination(model.transform.position);
        }
           
        
    }

    private void OnCollisionEnter(Collision other)
    {
       



    }
    private void OnCollisionExit(Collision other)
    {
        anim.Play("SphereChange");
        IsMove = true;



    }






}
