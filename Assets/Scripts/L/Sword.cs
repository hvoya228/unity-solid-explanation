using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item, IUsable
{
    public override void GetDescription()
    {
        Debug.Log("I am sword and can attack");
    }

    public void Use()
    {
        Debug.Log("Attack...");
    }
}
