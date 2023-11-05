using UnityEngine;

namespace Inheritance
{
    public class Npc : Character
    {
        protected override void Update()
        {
            base.Update();
            DoSomeAiMovement();
        }

        private void DoSomeAiMovement()
        {
            Debug.Log("navmesh");
        }
    }
}