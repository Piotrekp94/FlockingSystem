using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BoidsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var elapsedTime = (float) Time.ElapsedTime;
        Entities.ForEach((ref Translation translation, ref BoidData waveData) =>
        {
            translation.Value = new float3(translation.Value.x, translation.Value.y, translation.Value.z);
        }).ScheduleParallel();
    }
}