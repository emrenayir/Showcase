using UnityEngine;

namespace Composition
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        
        public void Move(Vector3 movement)
        {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }
}