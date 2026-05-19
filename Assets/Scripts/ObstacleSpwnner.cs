using System.Collections;
using UnityEngine;

public class ObstacleSpwnner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] int numToSpawn = 10;
    [SerializeField] float waitPerSpawn = 2f;
    [SerializeField] float spawnWidth = 3f;
    [SerializeField] GameObject obstacleParent;

    private void Start()
    {

        /*
        for (int i = 0; i < numToSpawn; i++)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity, transform);
        }
        */

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(waitPerSpawn);
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, +spawnWidth),transform.position.y, transform.position.z);
            Instantiate(obstacle, transform.position, Random.rotation, obstacleParent.transform);
            numToSpawn--;
            
        }
    }
}
