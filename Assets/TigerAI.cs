using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TigerAI : MonoBehaviour {

    public Transform gohere;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public float timeLeft = 5;
    NavMeshAgent agent;
    public bool back = false;
    Rigidbody tbody;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        bool back = false;
        tbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
         
        

        timeLeft -= Time.deltaTime;
        if (back == false) {

            gohere = target1;
            agent.SetDestination(gohere.position);
            if (timeLeft <= 0) {
                
                timeLeft = 7;
                back = true;
            }
        }
        else if (back == true) {

            gohere = target2;
            agent.SetDestination(gohere.position);
            if (timeLeft <= 0)
            {

                timeLeft = 7;
                back = false;
            }

        }

	}
}
