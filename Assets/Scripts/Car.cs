using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public virtual void Drive()
    {
        Debug.Log("I am " + gameObject.name + " with driving system");
    }
}
