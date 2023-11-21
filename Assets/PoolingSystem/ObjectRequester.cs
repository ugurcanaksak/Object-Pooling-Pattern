using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.ObjectPooling
{
    public class ObjectRequester : MonoBehaviour
    {
        public string RequestedID;
        public int RequestAmount;
        private IEnumerator Start()
        {
            for (int i = 0; i < RequestAmount; i++)
            {
                yield return new WaitForSeconds(2f);
                ObjectPoolingManager.Instance.GetPoolObject(RequestedID);

            }
        }
    }
}
