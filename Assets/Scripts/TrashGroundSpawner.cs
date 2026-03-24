using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGroundSpawner : MonoBehaviour
{
    [Header("Prefabs to Spawn")]
    [SerializeField] private List<GameObject> prefabs;

    [Header("Spawn Areas (BoxColliders)")]
    [SerializeField] private List<BoxCollider> spawnAreas;

    [Header("Spawn Timing")]
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;

    [Header("Trash Parent")]
    [SerializeField] private Transform parent;

    [Header("Spawn Settings")]
    [SerializeField] private int trashQtyToSpawn = 10;
    private int trashSpawned = 0;
    [SerializeField] private int maxAttempts = 10;
    [SerializeField] private LayerMask overlapMask;
    private float yOffset = 0.1f;
    
    [Header("Player")]
    [SerializeField] private Transform player;
    [SerializeField] private float minDistanceFromPlayer = 10f;
    [SerializeField] private bool drawDistanceGizmos = false;
    
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (trashSpawned < trashQtyToSpawn)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        if (prefabs.Count == 0 || spawnAreas.Count == 0)
            return;

        GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
        BoxCollider box = spawnAreas[Random.Range(0, spawnAreas.Count)];

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 spawnPos = GetPointOnTopOfBox(box);

            if (!IsFarFromPlayer(spawnPos))
                continue;

            if (!IsPositionFree(prefab, spawnPos))
                continue;

            Spawn(prefab, spawnPos);
            trashSpawned++;
            return;
        }
    }

    bool IsFarFromPlayer(Vector3 position)
    {
        if (player == null)
            return true;

        float distance = Vector3.Distance(position, player.position);
        return distance >= minDistanceFromPlayer;
    }
    
    private void Spawn(GameObject prefab, Vector3 position)
    {
        GameObject obj = Instantiate(prefab, position, Quaternion.identity, parent);

        //temp
        obj.transform.localScale = Vector3.one;
        
        Collider col = obj.GetComponent<Collider>();
        if (col != null)
        {
            float height = col.bounds.extents.y;
            obj.transform.position += Vector3.up * height;
        }
    }

    bool IsPositionFree(GameObject prefab, Vector3 position)
    {
        Collider prefabCol = prefab.GetComponent<Collider>();
        if (prefabCol == null)
            return true;

        Vector3 halfExtents = prefabCol.bounds.extents;

        // Check if anything is already in this space
        Collider[] hits = Physics.OverlapBox(
            position,
            halfExtents,
            Quaternion.identity,
            overlapMask
        );

        return hits.Length == 0;
    }

    Vector3 GetPointOnTopOfBox(BoxCollider box)
    {
        Vector3 center = box.center;
        Vector3 size = box.size;

        float randomX = Random.Range(-size.x / 2f, size.x / 2f);
        float randomZ = Random.Range(-size.z / 2f, size.z / 2f);
        float topY = size.y / 2f;

        Vector3 localPoint = center + new Vector3(randomX, topY, randomZ);
        Vector3 worldPoint = box.transform.TransformPoint(localPoint);

        worldPoint.y += yOffset;

        return worldPoint;
    }
    
    void OnDrawGizmos()
    {
        if (player == null || !drawDistanceGizmos)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, minDistanceFromPlayer);
    }
}
