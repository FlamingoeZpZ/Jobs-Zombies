using UnityEngine;
using Version_3__Jobs_;
using Random = UnityEngine.Random;

namespace Version_1
{
    public class ZombieSpawner : MonoBehaviour
    {
     
        [SerializeField] private Transform[] zombiePrefabs;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float minSpawnRadius;
        
        [SerializeField] private float timeBetweenSpawns = 1f;
        [SerializeField] private int minSpawns = 1;
        [SerializeField] private int maxSpawns = 5;
        
        private float _currentSpawnTime;


        // Update is called once per frame
        void Update()
        {
            _currentSpawnTime -= Time.deltaTime;
            if (_currentSpawnTime < 0)
            {
                _currentSpawnTime = timeBetweenSpawns;
                SpawnZombies();
            }
        }

        public void SpawnZombies()
        {
            int spawns = Random.Range(minSpawns, maxSpawns);
            for (int i = 0; i < spawns; i++)
            {
                Vector2 spawnLocation = (Random.insideUnitCircle * spawnRadius) + new Vector2(minSpawnRadius, minSpawnRadius);
                Vector3 remapped = new Vector3(spawnLocation.x, 0, spawnLocation.y);
                
                Transform t = Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)], remapped + transform.position, Quaternion.identity);
                
                if(ZombieSystem.Instance)
                    ZombieSystem.Instance.AddZombie(t);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, minSpawnRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, spawnRadius + minSpawnRadius);
        }
    }
}
