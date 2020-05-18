using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int colums;
    [SerializeField] float horizontalSpacing;
    [SerializeField] float verticalSpacing;
    [SerializeField] float maxRowDistance;
    [SerializeField] Vector3 spawnCenter;

    Transform cameraTransform;

    int lastRowAdded = 0;
    int firstRowAdded = 0;

    Pool platformsPool;

    Queue<List<PoolObject>> platformObjects = new Queue<List<PoolObject>>();

    private void Start()
    {
        platformsPool = PoolManager.GetInstance().GetPool("PlatformPool");
        cameraTransform = Camera.main.transform;
        maxRowDistance = (rows / 2) * verticalSpacing;

        for (int i = 0; i < rows; i++)
        {
            AddRow();
        }
    }

    void Update()
    {
        Vector3 firstRowPos = new Vector3(spawnCenter.x,
                                          spawnCenter.y + (firstRowAdded * verticalSpacing),
                                          spawnCenter.z);

        // Distance between the camera and the first platform
        float dist = cameraTransform.position.y - firstRowPos.y;

        if (cameraTransform.position.y > firstRowPos.y && maxRowDistance < dist)
        {
            RemoveFirstRow();
            AddRow();
        }
    }

    void AddRow()
    {
        int randomPlatforms = Random.Range(1, colums);
        int[] randomSelection = new int[colums];
        
        do
        {
            int selector = Random.Range(0, randomSelection.Length);

            if (randomSelection[selector] == 0)
            {
                randomSelection[selector] = 1;
                randomPlatforms--;
            }

        } while (randomPlatforms > 0);


        List<PoolObject> platformsRow = new List<PoolObject>();

        for (int j = 0; j < randomSelection.Length; j++)
        {
            if (randomSelection[j] == 1)
            {
                PoolObject poolObject = platformsPool.GetPooledObject();
                poolObject.transform.position = new Vector3(spawnCenter.x + (horizontalSpacing * j),
                                                            spawnCenter.y + (verticalSpacing * lastRowAdded),
                                                            spawnCenter.z);

                platformsRow.Add(poolObject);
            }
        }

        lastRowAdded++;
        platformObjects.Enqueue(platformsRow);
    }

    void RemoveFirstRow()
    {
        List<PoolObject> firstRow = platformObjects.Dequeue();

        for (int i = 0; i < firstRow.Count; i++)
            firstRow[i].Recycle();

        firstRowAdded++;
    }

    public void ResetPlatforms()
    {
        firstRowAdded = 0;
        lastRowAdded = 0;
        platformsPool.ResetPool();
        platformObjects.Clear();

        if (platformsPool)
        {
            platformsPool.ResetPool();
            for (int i = 0; i < rows; i++)
                AddRow();
        }
    }
}
