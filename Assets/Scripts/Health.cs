using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 10;

    private void Start()
    {
        Debug.Log("I am " + gameObject.name + " and have " + health + " health");
    }
}
