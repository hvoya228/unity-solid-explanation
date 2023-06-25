using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour, IMonster
{
    private float speed = 20f;
    private float teleportationSpeed = 30f;

    public void Move()
    {
        Debug.Log($"I am Vampire and I`m moving with {speed} speed and do teleportation with {teleportationSpeed} speed");
    }
}
