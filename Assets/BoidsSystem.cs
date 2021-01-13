using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class BoidsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref BoidData waveData) =>
        {
            translation.Value = new float3(translation.Value.x, translation.Value.y, translation.Value.z) +
                                waveData.velocity;
        }).ScheduleParallel();
    }
}