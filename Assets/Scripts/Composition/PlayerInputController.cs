using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Composition
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;

        private void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            characterMovement.Move(movement);
        }
    }
}