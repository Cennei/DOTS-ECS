using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RotaringCubeAuthoring : MonoBehaviour
{

    public class Baker : Baker<RotaringCubeAuthoring>
    {
        public override void Bake(RotaringCubeAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new RotatingCube());
        }
    }

}

public struct RotatingCube : IComponentData
{

}
