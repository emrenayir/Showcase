using System;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class PlayerShooter : BaseShooter
    { 
        public override void Shoot()
        {
            var rotation = firePoint.rotation;
            rotation = Quaternion.Euler(Random.Range(-45, 45), rotation.eulerAngles.y, rotation.eulerAngles.z);
            firePoint.rotation = rotation;
            base.Shoot();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                Shoot();
            }
        }
    }
}
