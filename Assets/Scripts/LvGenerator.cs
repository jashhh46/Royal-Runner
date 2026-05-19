using System.Collections.Generic;
using UnityEngine;

public class LvGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] GameObject chunkParent;
    [SerializeField] int initialChunkAmount = 10;
    [SerializeField] int chunkLength = 10;
    [SerializeField] float moveSpeed = 10f;

    List<GameObject> chunks = new List<GameObject>() ;
    Camera mainCamera;
   // GameObject[] chunks = new GameObject[10];

    private void Start()
    {
        mainCamera = Camera.main;
        SpawnChunk();
    }
    private void Update()
    {
        MoveChunk();
    }
    private void SpawnChunk()
    {
        for (int i = 0; i < initialChunkAmount; i++)
        {
            float chunkZ;
            chunkZ = (i * chunkLength) + transform.position.z;

            Vector3 chunkPos = new Vector3(transform.position.x, transform.position.y, chunkZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent.transform);
            chunks.Add(newChunk);
        }
    }
    private void SpawnNewChunk()
    {
        float chunkZ;
        if (chunks.Count > 0)
        {
            // place new chunk after the last chunk to avoid gaps
            var last = chunks[chunks.Count - 1];
            chunkZ = last.transform.position.z + chunkLength;
        }
        else
        {
            chunkZ = transform.position.z;
        }

        Vector3 chunkPos = new Vector3(transform.position.x, transform.position.y, chunkZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkPos, Quaternion.identity, chunkParent.transform);
        chunks.Add(newChunk);
    }
    private void MoveChunk()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        // iterate backwards when removing items from the list
        for (int i = chunks.Count - 1; i >= 0; i--)
        {
            GameObject chunk = chunks[i];
            // move in world space along the generator's forward direction
            chunk.transform.Translate(-transform.forward * moveSpeed * Time.deltaTime, Space.World);

            if (chunk.transform.position.z <= mainCamera.transform.position.z - chunkLength)
            {
                // destroy then remove
                Destroy(chunk);
                chunks.RemoveAt(i);
                SpawnNewChunk();
            }
        }
        
    }
}
