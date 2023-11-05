using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

namespace Inheritance
{
    public class PlayerCharacter : Character
    {
        [SerializeField] private string className = "Warrior";
        
        protected override void Update()
        {
            base.Update();
            DoMovementFromInput();
        }

        private void DoMovementFromInput()
        {
            var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            transform.position += movement * (Time.deltaTime * moveSpeed);
        }
    }
}