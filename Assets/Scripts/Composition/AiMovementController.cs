using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Composition
{
    [RequireComponent(typeof(NavMeshAgent), typeof(CharacterMovement))]
    public class AiMovementController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private CharacterMovement characterMovement;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            if (!navMeshAgent.hasPath)
            {
                Vector3 destination = GetDestination();
                navMeshAgent.SetDestination(destination);
            }

            var direction = Vector3.Normalize(navMeshAgent.nextPosition - transform.position);
            characterMovement.Move(direction);
        }

        private Vector3 GetDestination()
        {
            return new Vector3(Random.Range(0, 20), transform.position.y, Random.Range(0, 20));
        }
    }
}