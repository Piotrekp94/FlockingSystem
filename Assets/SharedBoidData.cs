using System;
using Unity.Entities;

public struct SharedBoidData : ISharedComponentData
{
    private float range;
    public SharedBoidData(float range)
    {
        this.range = range;
    }
}