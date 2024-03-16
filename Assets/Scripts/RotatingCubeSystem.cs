using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct RotatingCubeSystem : ISystem
{

    public void OnCreate(ref SystemState state)
    {

        state.RequireForUpdate<RotateSpeed>(); // runs when there is at least one entity with that component

    }

    [BurstCompile]

    public void OnUpdate(ref SystemState state) 
    {
        state.Enabled = false;
        return;
        /*
        foreach (var ( localTransform, rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()) //RefRW means Read and Write (RefRO for Read only)
        {

            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime); 

        } 
        */
        RotatingCubeJob rotatingCubeJob = new RotatingCubeJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        rotatingCubeJob.Schedule();
    }

    [BurstCompile]
    [WithAll(typeof(RotatingCube))]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float deltaTime;

        public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
        {
        localTransform = localTransform.RotateY(rotateSpeed.value* deltaTime);

        }

    }

}
