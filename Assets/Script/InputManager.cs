using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController player;

    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.Find("Player");
        if (obj != null)
        {
            if (!GameObject.Find("Player").TryGetComponent<PlayerController>(out player))
                Debug.Log("InputManager.cs - Awake() - player 참조 실패.");
        }
        else
            Debug.Log("InputManager.cs - Awake() - player 오브젝트 탐색 실패.");
    }

    private void OnMouseDown()
    {
        player.MoveInput = true;
    }
    private void OnMouseUp()
    {
        player.MoveInput = false;
    }
}
