using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitiesSpawner : MonoBehaviour
{
    [SerializeField] [RuntimeReadOnly] private Mesh mesh;
    [SerializeField] [RuntimeReadOnly] private Material material;
    [SerializeField] [RuntimeReadOnly] private float boids;
    [SerializeField] [RuntimeReadOnly] private float3 startingVelocity;
    [SerializeField] [RuntimeReadOnly] private int minSpawnBound;
    [SerializeField] [RuntimeReadOnly] private int maxSpawnBound;


    
    [SerializeField] private float range;

    private List<Entity> _entites;
    private EntityManager _entityManager;
    private void Start()
    {
       
        _entites = new List<Entity>();
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (var i = 0; i < boids; i++)
        {
            var archetype = _entityManager.CreateArchetype(
                typeof(Translation),
                typeof(Rotation),
                typeof(RenderMesh),
                typeof(RenderBounds),
                typeof(LocalToWorld));
            var e = _entityManager.CreateEntity(archetype);
            _entityManager.AddComponentData(e, new Translation {Value = new float3(Random.Range(minSpawnBound,maxSpawnBound), Random.Range(minSpawnBound,maxSpawnBound),Random.Range(minSpawnBound,maxSpawnBound))});
            _entityManager.AddComponentData(e, new BoidData(startingVelocity));
            _entityManager.AddSharedComponentData(e, new SharedBoidData(range));
            _entityManager.AddSharedComponentData(e, new RenderMesh {mesh = mesh, material = material});
            _entites.Add(e);
        }
    }
}
