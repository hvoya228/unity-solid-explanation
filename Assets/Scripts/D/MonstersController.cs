using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersController : MonoBehaviour
{
    [SerializeField] private Zombie zombie;
    [SerializeField] private Vampire vampire;

    private void Start()
    {
        zombie.Move();
        vampire.Move();
    }
}
