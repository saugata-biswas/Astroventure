using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionBaseFSM : StateMachineBehaviour
{
    [SerializeField] protected GameObject CompanionNPC;
    [SerializeField] protected GameObject targetGmObj;
    protected NavMeshAgent navMeshAgent;

    //[SerializeField] protected float speed = 2.0f;
    //[SerializeField] protected float rotationSpeed = 1.0f;
    //[SerializeField] protected float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CompanionNPC = animator.gameObject;
        targetGmObj = CompanionNPC.GetComponent<CompanionBrain>().GetTargetGmObj();

        navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
    }
}
