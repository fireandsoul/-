using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMOnEnter : StateMachineBehaviour
{

    public string[] OnEnterMessages;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(var msg in OnEnterMessages)
        {
            animator.gameObject.SendMessageUpwards(msg);
        }
    }

    
}
