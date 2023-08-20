using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    private float meteoSpawnRate = 5.0f;

    private int spawnCounter;

    private void Awake()
    {
        StartCoroutine("SpawnAlertLine");
        spawnCounter = 0;
    }

    private GameObject spawnObj;
    private Vector3 spawnPos;
    IEnumerator SpawnAlertLine()
    {
        while (true)
        {
            yield return YieldInstructionCache.WaitForSeconds(meteoSpawnRate);
            spawnObj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Meteorite_02].Pop();
            spawnPos = Vector3.zero;
            spawnPos.x = Random.Range(-2.5f, 2.5f);
            spawnObj.transform.position = spawnPos;

            spawnCounter++;
            meteoSpawnRate = 5f - 0.2f * spawnCounter;
            if (meteoSpawnRate < 0.7f)
            {
                meteoSpawnRate = 0.7f;
            }
        }
    }
}
