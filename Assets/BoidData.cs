using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct BoidData : IComponentData
{
    private Vector3 velocity;

    public BoidData(Vector3 velocity)
    {
        this.velocity = velocity;
    }
}
