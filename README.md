# Explanation  

**Before we get started, you have to understand that SOLID is abstract thing and can have many diferent explanations and implementation methods!**  

### What is SOLID?  
*SOLID - is set of rules, by following which you will have flexible and easier to understand project.    
Following solid rules is great for team project to have understanding the code of each other,  
without studying the approach to each individual's work.  
Also you will get a flexible project to adding smth new in the future and will avoid many bugs during development.*  

---

### Single responsibility  
*Each object or script should have a single responsibility, this helps keep your code clean and easy to understand.  
Avoid having overloaded scripts that do too many different things.  
Instead, separate functionality into individual scripts with clear responsibilities.*  

**Example:**  

Imagine that we have two implement a Human player.  
Our Human have health and he have to move:  
```c#
public class Human : MonoBehaviour
{
    [SerializeField] private int health;

    private void Start()
    {
        GetHealth();
        Move();
    }

    private void GetHealth()
    {
        Debug.Log($"I am {gameObject.name} and have {health} health");
    }

    private void Move()
    {
        Debug.Log($"I am {gameObject.name} with movement system");
    }
}
```

We are realized this ideas in the same class, but firstly it`s inconveniently.  
And will cause a problem if we want to make second Player, which is Ghost, with movement system but without health.  

So, you have to separate your class that including health and movement:   
```c#
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
```  

```c#
public class MoveSystem : MonoBehaviour
{
    private void Start()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log($"I am {gameObject.name} with movement system");
    }
}
```

Now you can give a movement component to both players, but health only for Human.      

---  

### Open/Colsed  
Code should be open for extension but closed for modification.  

**Example:**  

Imagine that we have a car with Car.cs script attached. Car can drive:    
```c#
public class Car : MonoBehaviour
{
    [SerializeField] private float speed;

    public virtual void Drive()
    {
        Debug.Log($"I am { gameObject.name} with driving system and {speed} speed");
    }
}
```  

During the development you want to add a sport car to your game. First thing that comes to mind is to modify the Car.cs script.  
This is wrong! Your modifications, with many if and other checks can make your previously worked code - not working.  
It`s better to make other script for sport car, but with previous car opportunities.  
We can make this with inheritance and polymorphism:  
```c#
public class SportCar : Car
{
    public void Nitro()
    {
        Debug.Log($"I am {gameObject.name} with nitro speed-up");
    }
}
```

**Open/Closed problems solving can have many implementations, not only inheritance!**  

Now we can use two diferent cars with same drive system:  
```c#
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
```

---

