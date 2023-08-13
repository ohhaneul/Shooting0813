using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    protected ObjectPool pool;  //  해당 오브젝트를 관리하는 오브젝트 풀 레퍼런싱
    


    public virtual void Create(ObjectPool objectPool)
    {
        this.pool = objectPool;
        gameObject.SetActive(false);
    }

    //풀에서 꺼내 갈 때 속성값을 초기화 하기 위한 함수
    public virtual void InitInfo()
    {

    }

    public virtual void Push()
    {
        pool.Push(this);
    }
}
