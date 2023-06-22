using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item, IUsable
{
    public override void GetDescription()
    {
        Debug.Log("I am health potion and can heal you");
    }

    public void Use()
    {
        Debug.Log("Healing...");
    }
}
