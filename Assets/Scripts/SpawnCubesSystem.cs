using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public partial class SpawnCubesSystem : SystemBase
{

    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubesConfig>();
    }

    protected override void OnUpdate()
    {

        this.Enabled = false;

        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        for (int i = 0; i < spawnCubesConfig.amountToSpawn; i++) 
        {

            Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.cubePrefabEtity);
            SystemAPI.SetComponent(spawnedEntity, new LocalTransform
            {

                Position = new float3(UnityEngine.Random.Range(-10f, 5f), 0.6f, UnityEngine.Random.Range(-4f, 7f)),
                Rotation = quaternion.identity,
                Scale = 1f,

            });

        }
    }
}
