using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnTriggerNameSpace;
namespace OnTriggerNameSpace
{
    public class OnTrigger : MonoBehaviour
    {
        public float maxDistance = 8.0f;
        public GameObject target;
        public GameObject me;

        public int Trigger(Collider2D other)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            //Debug.Log(distance);
            // If the player is within the maximum distance of the door, display the keypad
            if (distance <= maxDistance)
            {
                return 1;
            }
            return 0;
        }
    }
}
