using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    private void Start()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log($"I am {gameObject.name} with movement system");
    }
}
