using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IMonster
{
    private float speed = 10f;

    public void Move()
    {
        Debug.Log($"I am Zombie and I`m moving with {speed} speed");
    }
}
