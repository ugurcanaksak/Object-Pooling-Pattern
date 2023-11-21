using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.ObjectPooling
{
    public class PooledObject : MonoBehaviour, IPooledObject
    {
        public Transform t => transform;


        public void Initialize()
        {
            Debug.Log($"{gameObject.name} Initialized");
        }

        public void Dismiss()
        {
            Debug.Log($"{gameObject.name} Dismiss");
        }
    }
}
