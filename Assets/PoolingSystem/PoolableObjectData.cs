using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.ObjectPooling
{
    [CreateAssetMenu(menuName = "RobotDreams/PoolableObject")]
    public class PoolableObjectData : ScriptableObject
    {
        public string ObjectName;
        public GameObject Prefab;
        public int Amount;
    }
}
