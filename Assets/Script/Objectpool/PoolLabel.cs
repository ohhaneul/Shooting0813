using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    protected ObjectPool pool;  //  �ش� ������Ʈ�� �����ϴ� ������Ʈ Ǯ ���۷���
    


    public virtual void Create(ObjectPool objectPool)
    {
        this.pool = objectPool;
        gameObject.SetActive(false);
    }

    //Ǯ���� ���� �� �� �Ӽ����� �ʱ�ȭ �ϱ� ���� �Լ�
    public virtual void InitInfo()
    {

    }

    public virtual void Push()
    {
        pool.Push(this);
    }
}
