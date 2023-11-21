using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.ObjectPooling
{
    public class ObjectDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            IPooledObject pooledObject = collision.transform.GetComponent<IPooledObject>();

            if(pooledObject != null)
            {
                ObjectPoolingManager.Instance.ReturnPooledObject(pooledObject.t.gameObject);
            }
        }
    }
}
