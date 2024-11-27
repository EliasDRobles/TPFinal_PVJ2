using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformFactoryBase : MonoBehaviour
{
    public abstract GameObject CreatePlatform(Vector3 position, float speed, float maxDistance);
}
