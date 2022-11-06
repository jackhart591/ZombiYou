using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour {

    [SerializeField] private Transform playerPos;
    private NavMeshAgent navMeshAgent;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        navMeshAgent.speed = GetComponent<Enemy>().MoveSpeed;
    }

    private void Update() {
        if (GetComponent<Enemy>().awake)
            navMeshAgent.destination = playerPos.position;
    }
}
