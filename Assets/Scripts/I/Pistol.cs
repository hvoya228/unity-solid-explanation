using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IHotWeapon
{
    private void Start()
    {
        Attack();
        Reload();
    }

    public void Attack()
    {
        Debug.Log("Pistol attack...");
    }

    public void Reload()
    {
        Debug.Log("Pistol reload...");
    }
}
