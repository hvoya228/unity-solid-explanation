using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportCar : Car
{
    public void Nitro()
    {
        Debug.Log("I am " + gameObject.name + " with nitro speed-up");
    }
}
