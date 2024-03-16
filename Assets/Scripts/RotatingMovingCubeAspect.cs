using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct RotatingMovingCubeAspect : IAspect
{

    public readonly RefRW<LocalTransform> localTransform;
    public readonly RefRW<RotateSpeed> rotateSpeed;
    public readonly RefRW<Movement> movement;

    public void MoveAndRotate(float deltaTime)
    {

        localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * deltaTime);
        localTransform.ValueRW = localTransform.ValueRO.Translate(movement.ValueRO.movementVector * deltaTime);

    }
}
