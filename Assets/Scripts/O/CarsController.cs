using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private SportCar sportCar;

    private void Start()
    {
        car.Drive();
        sportCar.Drive();
        sportCar.Nitro();
    }
}
