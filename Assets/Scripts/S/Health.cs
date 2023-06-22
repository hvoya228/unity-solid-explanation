using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    private void Start()
    {
        GetHealth();
    }

    private void GetHealth()
    {
        Debug.Log($"I am {gameObject.name} and have {health} health");
    }
}
