using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    OT_Projectile_01,
    OT_Projectile_02,
    OT_Projectile_03,
    OT_Projectile_04,
    OT_Projectile_05,
    OT_Projectile_06,
    OT_Enemy_01,
    OT_Enemy_02,
    OT_Enemy_03,
    OT_Meteorite_01,
    OT_Meteorite_02,
    OT_Item_01,
    OT_Item_02,
    OT_Item_03,
    OT_Item_04,
    OT_Effect_01,
    OT_Boom_01,

}

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager instance;

    public static ObjectPoolManager Inst
    {
        get => instance;
    }

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public List<ObjectPool> pools;
}