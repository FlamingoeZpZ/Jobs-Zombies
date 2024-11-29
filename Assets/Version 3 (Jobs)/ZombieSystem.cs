using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using Version_1;

namespace Version_3__Jobs_
{
    [BurstCompile]
    public class ZombieSystem : MonoBehaviour
    {
        private TransformAccessArray _zombieTransforms;
        private bool _hasEdits;

        
        
        public static ZombieSystem Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            _zombieTransforms = new TransformAccessArray(0);
        }


        private void Update()
        {
            ZombieMoveJob job = new ZombieMoveJob()
            {
                DeltaTime = Time.deltaTime,
                TargetLocation = Player.PlayerLocation,
                MoveSpeed = 1
            };
            JobHandle jobHandle = job.Schedule(_zombieTransforms);
            jobHandle.Complete(); // wait to complete
        }

        public void AddZombie(Transform t)
        {
            _zombieTransforms.Add(t.transform);
        }

        public void RemoveZombie(int index)
        {
            _zombieTransforms.RemoveAtSwapBack(index);
        }

        private void OnDestroy()
        {
            //Dispose to prevent memory leaks
            if(_zombieTransforms.isCreated) _zombieTransforms.Dispose();
        }
    }


    [BurstCompile]
    public struct ZombieMoveJob : IJobParallelForTransform
    {
        [ReadOnly] public float3 TargetLocation;
        [ReadOnly] public float DeltaTime;
        [ReadOnly] public float MoveSpeed;
        public void Execute(int index, TransformAccess transform)
        {
            float3 loc = transform.position;
            float3 target =   TargetLocation-loc;
            target = math.normalize(target);
            transform.SetPositionAndRotation(loc+ (target *  (MoveSpeed * DeltaTime)), quaternion.LookRotation(target, Vector3.up));
        }
    }
}