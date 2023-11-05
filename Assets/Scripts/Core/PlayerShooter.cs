using System;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class PlayerShooter : BaseShooter
    { 
        private float m_TimePassed;
        private bool m_IsRotating = true;
        private float m_LastShootTime;
        [SerializeField]
        private float fireRate = 1f; 
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S) && Time.time - m_LastShootTime >= fireRate)
            {
                Shoot();
                m_LastShootTime = Time.time;
                m_IsRotating = false;
                Invoke(nameof(ReleaseRotation), 1);
            }
            else
            {
                if (m_IsRotating)
                {
                    m_TimePassed += Time.deltaTime;
                    float rotationValue = Mathf.PingPong(m_TimePassed * 90, 90) - 45;
                    var rotation = firePoint.rotation;
                    rotation = Quaternion.Euler(rotationValue, rotation.eulerAngles.y, rotation.eulerAngles.z);
                    firePoint.rotation = rotation;
                }
            }
        }
        private void ReleaseRotation()
        {
            m_IsRotating = true;
        }
    }
}
