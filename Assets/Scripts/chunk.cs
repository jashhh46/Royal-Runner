using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{
    [SerializeField] float[] lanes = { -3, 0, 3 };
    [SerializeField] GameObject fence;
    [SerializeField] GameObject coin;

    List<int> availablelLanes = new List<int> { 0, 1, 2 };


    private void Start()
    {
        SpawnFence();
        SpawnCoin();
    }

    private void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availablelLanes.Count <= 0) break;

            int randomLaneIndex = Random.Range(0, availablelLanes.Count);
            int selectedLane = availablelLanes[randomLaneIndex];
            availablelLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fence, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void SpawnCoin()
    {
       // if (availablelLanes.Count == 0) return;

        int laneIndex = availablelLanes[0];
        Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y + 0.7f, transform.position.z);
        Instantiate(coin, spawnPosition, Quaternion.identity, transform);
    }
}   