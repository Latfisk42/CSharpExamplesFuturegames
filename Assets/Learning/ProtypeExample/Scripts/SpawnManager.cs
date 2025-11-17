using Learning.Prototype;
using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Learning.Prototype
{
    public sealed class SpawnManager : MonoBehaviour{
        public Player player;
        public Enemy enemyPrefab;
        public Transform[] spawnPoints;
        private float nextSpawn = 0;

        public void EnemySpawner()
        {
            if(!GameData.gameIsOver && !GameData.gameIsPaused && Time.time > nextSpawn) {
                nextSpawn = Time.time + Random.Range(1f, 3f);
                int r = Random.Range(0, spawnPoints.Length);
                Enemy enemy = Object.Instantiate(enemyPrefab, spawnPoints[r].position, spawnPoints[r].rotation);
                enemy.transform.position = new Vector3(enemy.transform.position.x + Random.Range(1f, 3f), enemy.transform.position.y, enemy.transform.position.z + Random.Range(1f, 3f));
                enemy.transform.LookAt(player.transform);
                StartMovingTowardsPlayer(enemy);
            }
        }
        private void StartMovingTowardsPlayer(Enemy enemy) {
            enemy.StartMovingTowards(player.transform);
        }

        private void Update() {
            EnemySpawner();
        }
    }
}
