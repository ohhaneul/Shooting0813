using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private PoolLabel label;
    private void OnTriggerExit2D(Collider2D collision)//´ÙÇü¼º
    {
        if (collision.TryGetComponent<PoolLabel>(out label))
        {
            label.Push();
        }
        else
            Destroy(collision.gameObject);
    }
}
