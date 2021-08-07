using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBaseFSM : StateMachineBehaviour
{
    [SerializeField] protected GameObject NPC;
    [SerializeField] protected GameObject targetGmObj;
    protected NavMeshAgent navMeshAgent;

    //[SerializeField] protected float speed = 2.0f;
    //[SerializeField] protected float rotationSpeed = 1.0f;
    //[SerializeField] protected float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        targetGmObj = NPC.GetComponent<NPCBrain>().GetTargetGmObj();
        
        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
    }
}
