using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int colums;
    [SerializeField] float horizontalSpacing;
    [SerializeField] float verticalSpacing;
    [SerializeField] Vector3 spawnCenter;

    [SerializeField] Transform spawnDistancePosition;

    List<List<PoolObject>> poolObjects = new List<List<PoolObject>>();
    Pool platformsPool;

    private void Start()
    {
        platformsPool = PoolManager.GetInstance().GetPool("PlatformPool");

        for (int i = 0; i < rows; i++)
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
            

            for (int j = 0; j < randomSelection.Length; j++)
            {
                if (randomSelection[j] == 1)
                {
                    PoolObject poolObject = platformsPool.GetPooledObject();
                    poolObject.transform.position = new Vector3(spawnCenter.x + (horizontalSpacing * j), 
                                                                spawnCenter.y + (verticalSpacing * i), 
                                                                spawnCenter.z);
                }
            }

        }
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(spawnDistancePosition.position.x, spawnDistancePosition.position.y, spawnCenter.z);

        /*new Vector3(spawnCenter.x + (horizontalSpacing * j), 
                                                                spawnDistancePosition.position.y - (((float)rows / 2f) * verticalSpacing) + (verticalSpacing * i), 
                                                                spawnCenter.z);*/
    }
}
