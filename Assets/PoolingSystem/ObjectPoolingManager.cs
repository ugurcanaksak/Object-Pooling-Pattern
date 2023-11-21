using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RobotDreams.ObjectPooling
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        public static ObjectPoolingManager Instance;

        [SerializeField]
        private List<PoolableObjectData> _objectsToPool = new List<PoolableObjectData>();

        private Dictionary<string, List<GameObject>> _pooledObjects = new Dictionary<string, List<GameObject>>();

        private void Awake()
        {
            Instance = this;
            Init();
        }

        private void Init()
        {
            //Create Clones
            //Go to each data in the _objectsToPool list
            foreach (var objectToPoolData in _objectsToPool)
            {
                //Create container
                var parent = new GameObject(objectToPoolData.ObjectName + "s").transform;
                parent.transform.SetParent(transform);

                //Init a new list to the dictionary for the clones
                var pooledObjectList = _pooledObjects[objectToPoolData.ObjectName] = new List<GameObject>();

                //Create clones
                for (int i = 0; i < objectToPoolData.Amount; i++)
                {
                    var cloneObject = CreateClone(objectToPoolData.Prefab, parent);
                    pooledObjectList.Add(cloneObject);

                }
            }
        }


        public GameObject GetPoolObject(string id)
        {
            var cloneList = _pooledObjects[id];


            var clone = cloneList.Where(clone => !clone.activeInHierarchy).FirstOrDefault();

            if (clone == null)
            {
                clone = CreateClone(_objectsToPool
                    .Where(objectData => string.Equals(objectData.ObjectName, id))
                    .FirstOrDefault().Prefab,
                    transform.Find(id + "s"));


                cloneList.Add(clone);
            }

            clone.SetActive(true);
            clone.GetComponent<IPooledObject>()?.Initialize();

            return clone;
        }

        private GameObject CreateClone(GameObject clonePrefab, Transform parent)
        {
            var cloneObject = Instantiate(clonePrefab, parent);
            cloneObject.SetActive(false);
            return cloneObject;
        }

        public void ReturnPooledObject(GameObject objectToReturn)
        {
            objectToReturn.GetComponent<IPooledObject>()?.Dismiss();
            objectToReturn.SetActive(false);
        }
    }
}
