using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlayerMovement : MonoBehaviour,IJump
    {
        [SerializeField] private float startingJumpForce;
        private Rigidbody m_PlayerRb;
        private int m_JumpCount = 0;
        private bool m_IsGrounded;
    
        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask groundLayer;

        private void Awake()
        {
            m_PlayerRb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Jump(startingJumpForce);
            CheckGround();
        }
        public void Jump(float jumpForce)
        {
            var down = Input.GetKeyDown(KeyCode.Space);
        
            if(down &&  m_JumpCount < 1)
            {
                m_PlayerRb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                ++m_JumpCount;
            }
        }
        private void CheckGround()
        {
            m_IsGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
            if (m_IsGrounded)
            {
                m_JumpCount = 0;
            }
        }
    }
}
