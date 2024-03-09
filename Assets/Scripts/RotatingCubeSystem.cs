using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct RotatingCubeSystem : ISystem
{

    public void OnCreate(ref SystemState state)
    {

        state.RequireForUpdate<RotateSpeed>(); // runs when there is at least one entity with that component

    }

    public void OnUpdate(ref SystemState state) 
    {
        
        foreach (var ( localTransform, rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()) //RefRW means Read and Write (RefRO for Read only)
        {

            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime); 

        } 

    }

}
