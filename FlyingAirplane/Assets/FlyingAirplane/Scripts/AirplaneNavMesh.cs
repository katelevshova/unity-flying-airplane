using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirplaneNavMesh : MonoBehaviour
{
	[SerializeField] NavMeshAgent navMeshAgent;     

	void Reset()
	{
		//Get a reference to the navmesh agent
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void Update()
	{
		//Tell the navmesh agent to move to the designated point
		navMeshAgent.SetDestination(GameController.Instance.target.transform.position);
	}
}
