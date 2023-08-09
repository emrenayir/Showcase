using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class EnemyMovement : MonoBehaviour,IJump
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

        private void Start()
        {
            StartCoroutine(JumpRoutine());
        }

        private void Update()
        {
            CheckGround();
        }
        
        public void Jump(float jumpForce)
        {
            if(m_JumpCount < 1)
            {
                m_PlayerRb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                ++m_JumpCount;
                
                if (Random.value < 0.5f)
                {
                    StartCoroutine(SecondJump());
                }
            }
        }
        private IEnumerator SecondJump()
        {
            yield return new WaitForSeconds(0.2f);
            if (m_JumpCount < 1)
            {
                m_PlayerRb.AddForce(new Vector3(0, startingJumpForce, 0), ForceMode.Impulse);
                m_JumpCount++;
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
        private IEnumerator JumpRoutine()
        {
            while (true)
            {
                float waitTime = Random.Range(1f, 3f); // Zıplama aralığı
                yield return new WaitForSeconds(waitTime);
                Jump(startingJumpForce);
            }
        }
    }
}