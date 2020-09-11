using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMClearSignals : StateMachineBehaviour
{
    public string[] clearAtEnter;
    public string[] clearAtExit;


    // Start is called before the first frame update
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var signals in clearAtEnter)
        {
            animator.ResetTrigger(signals);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var signals in clearAtExit)
        {
            animator.ResetTrigger(signals);
        }
    }




}
