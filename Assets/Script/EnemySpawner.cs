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
    private int bossSpawnCounter = 10;  // ������ �����ϱ� ���� ���̺� ������ �� �� ���͸� �����ؾ� �ϴ���
    private int currentCounter = 0;

    private int waveCount; // ���� �� �� ���̺갡 ����ǰ� �ִ���


    private void Awake()
    {
        waveCount = 0;

        StartWave();
    }


    //���̺� ���� �����ִ� �Լ�
    public void StartWave()
    {
        currentCounter = 0;
        StartCoroutine("SpawnEvent");
    }

    //���� �Ϲ� ���͸� �ݺ������� ���������ִ� �Լ�
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
                //10������ ȣ��
            }
        }
    }
}
