using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnCubeConfigAuthoring : MonoBehaviour
{

    public GameObject cubePrefab;
    public int amountToSpawn;

    public class Baker : Baker<SpawnCubeConfigAuthoring>
    {
        public override void Bake(SpawnCubeConfigAuthoring authoring)
        {
            
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new SpawnCubesConfig
            {
                cubePrefabEtity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
                amountToSpawn = authoring.amountToSpawn,
            });

        }
    }

}

public struct SpawnCubesConfig : IComponentData
{

    public Entity cubePrefabEtity;
    public int amountToSpawn;

}