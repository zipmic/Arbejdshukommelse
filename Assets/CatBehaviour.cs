using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBehaviour : MonoBehaviour {

    private GameObject Target;

    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {

        Target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("CatWalk", 2, 3);
	}
	
	// Update is called once per frame
	void CatWalk () 
    {


        agent.SetDestination(Target.transform.position);


	}
}
