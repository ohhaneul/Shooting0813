using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLine : PoolLabel
{

    private Animator anim;
    private void Awake()
    {
        if (!TryGetComponent<Animator>(out anim))
            Debug.Log("AlertLine - Awake - anim ½ÇÆÐ");
    }

    public override void InitInfo()
    {
        base.InitInfo();
        anim.SetTrigger("Alert");
        Invoke("SpawnMeteo", 3.0f);

    }
    private Vector3 spawnPos;
    private GameObject spawnObj;

    private void SpawnMeteo()
    {
        spawnPos = transform.position;
        spawnPos.y = 6.0f;

        spawnObj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Meteorite_01].Pop();
        spawnObj.transform.position = spawnPos;
        Push();

    }
}
