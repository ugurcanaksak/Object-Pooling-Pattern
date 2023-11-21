using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.ObjectPooling
{
    public interface IPooledObject 
    {
        Transform t { get; }

        void Initialize();
        void Dismiss();
    }
}
