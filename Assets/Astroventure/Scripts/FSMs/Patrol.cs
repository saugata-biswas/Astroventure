// this script has been adapted from: https://www.youtube.com/watch?v=NEvdyefORBo,
// https://www.youtube.com/watch?v=tdYsq96kCYI,
// https://www.youtube.com/watch?v=5qDadIloxvU
// https://www.youtube.com/watch?v=NGGoOa4BpmY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : NPCBaseFSM
{
    GameObject[] waypoints;
    int currentWP;
    

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        currentWP = Random.Range(0, waypoints.Length - 1);
        Vector3 targetVector = waypoints[currentWP].transform.position;

        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(targetVector);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < Random.Range(0.1f, 2.0f))
        {
            //currentWP++;
            //if (currentWP >= waypoints.Length)
            //    currentWP = 0;
            currentWP = Random.Range(0, waypoints.Length - 1);

            if (navMeshAgent != null)
            {
                Vector3 targetVector = waypoints[currentWP].transform.position;
                if (navMeshAgent.enabled)
                    navMeshAgent.SetDestination(targetVector);
            }

            //if (Random.value > 0.8)
            //    animator.SetBool("Wandering", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
