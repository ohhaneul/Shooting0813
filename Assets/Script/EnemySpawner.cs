using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject spawnObj;

    [SerializeField]
    private List<Transform> spawnTrans;
    [SerializeField]
    private float spawnDelta;

    [SerializeField]
    private int bossSpawnCounter = 10;  // 보스를 스폰하기 위해 웨이브 내에서 몇 번 몬스터를 스폰해야 하는지
    private int currentCounter = 0;

    private int waveCount; // 현재 몇 번 웨이브가 진행되고 있는지


    private void Awake()
    {
        waveCount = 0;

        StartWave();
    }


    //웨이브 시작 시켜주는 함수
    public void StartWave()
    {
        currentCounter = 0;
        StartCoroutine("SpawnEvent");
    }

    //실제 일반 몬스터를 반복적으로 스폰시켜주는 함수
    IEnumerator SpawnEvent()
    {
        waveCount++;

        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(spawnDelta);
            currentCounter++;
            for (int i = 0; i < 5; i++)
            {
                spawnObj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Enemy_01 + waveCount -1].Pop();
                spawnObj.transform.position = spawnTrans[i].position;
                spawnObj.transform.rotation = spawnTrans[i].rotation;
            }

            if (currentCounter == bossSpawnCounter)
            {
                StopCoroutine("SpawnEvent");
                //10번까지 호출
            }
        }
    }
}
