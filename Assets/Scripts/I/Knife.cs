using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IColdWeapon
{
    private void Start()
    {
        Attack();
    }

    public void Attack()
    {
        Debug.Log("Knife attack...");
    }
}
