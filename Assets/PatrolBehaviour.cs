using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour {

    public float speed = 5.0f;
    public GameObject patrolPointsPrefab;
    Transform patrolPoints;
    int randomPoint;


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (patrolPoints == null) {
            patrolPoints = Instantiate(patrolPointsPrefab).transform;
        }

        randomPoint = Random.Range(0, patrolPoints.childCount);
	
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Vector2 current = animator.transform.position;
        Vector2 target = patrolPoints.GetChild(randomPoint).position;

        if (Vector2.Distance(current, target) > 0.2f ) {
            animator.transform.position = Vector2.MoveTowards(current, target, speed * Time.deltaTime);
        } else {
            randomPoint = Random.Range(0, patrolPoints.childCount);
        }


	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
