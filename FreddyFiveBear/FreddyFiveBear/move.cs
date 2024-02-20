using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FreddyFiveBear
{
    internal class move : MonoBehaviour
    {
        public GameObject freddy;
        public float speed = 1;
        void Update()
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            freddy.transform.position = Vector3.MoveTowards(freddy.transform.position, GorillaTagger.Instance.bodyCollider.gameObject.transform.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(freddy.transform.position, GorillaTagger.Instance.bodyCollider.gameObject.transform.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                GorillaTagger.Instance.bodyCollider.gameObject.transform.position *= -1.0f;
            }
            // Determine which direction to rotate towards
            Vector3 targetDirection = GorillaTagger.Instance.bodyCollider.gameObject.transform.position - freddy.transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(freddy.transform.forward, targetDirection, singleStep, 0.0f);



            // Calculate a rotation a step closer to the target and applies rotation to this object
            freddy.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
