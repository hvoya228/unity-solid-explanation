# Explanation  

**Before we get started, you have to understand that SOLID is abstract thing and can have many diferent explanations and implementation methods!**  
**And all examples are very simple to give you only understanding of SOLID!***

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

### Liskov Substitution  
*Subclasses should be substitutable for their base classes without affecting the correctness of the program.  
In Unity, this can involve creating a base class or interface  
that describes the common functionality and then creating subclasses that extend this functionality while adhering to the interface.*  

*On other words, when you gives child class to parent`s class variable and you handle this variable it is have to work correctly,
without extra methods.*  

**Example:**  

You have to make a inventory with items in your game.  
You added an abstract class for items, some items and controller for them:  
```c#
public abstract class Item : MonoBehaviour
{
    public abstract void GetDescription();
    public abstract void Use();
}
```

```c#
public class Sword : Item
{
    public override void GetDescription()
    {
        Debug.Log("I am sword and can attack");
    }

    public override void Use()
    {
        Debug.Log("Attack...");
    }
}
```

```c#
public class HealthPotion : Item
{
    public override void GetDescription()
    {
        Debug.Log("I am health potion and can heal you");
    }

    public override void Use()
    {
        Debug.Log("Healing...");
    }
}
```

```c#
public class ItemsController : MonoBehaviour
{
    [SerializeField] private List<Item> items;

    private void Start()
    {
        foreach (var item in items)
        {
            item.GetDescription();
            item.Use();
        }
    }
}
```

Items controller working with different items but with the same class, everything great.  
But you also have to add a Junk item, which have description but doing nothing.  
We can make this item like this:  
```c#
public class Junk : Item
{
    public override void GetDescription()
    {
        Debug.Log("I am junk and do nothing");
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
```

You can see that Use method is muffled with exception, so this is a problem of Liskov Substitution.  
We have to solve it, your code must be without this "muffled thinks".  

In this case we can make IUsable interface with Use method to implement him in all items, but don`t in Junk item.  
And remove the Use method from Item.cs script.
```c#
public interface IUsable
{
    public void Use();
}
```

```c#
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
```

```c#
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
```

```c#
public class Junk : Item
{
    public override void GetDescription()
    {
        Debug.Log("I am junk and do nothing");
    }
}
```

```c#
public class ItemsController : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    private List<IUsable> usableItems;

    private void Start()
    {
        SetUsableItems();
        GetItemsDescription();
        UseItems();
    }

    private void SetUsableItems()
    {
        usableItems = new List<IUsable>();

        foreach (var item in items)
        {
            if (item is IUsable)
            {
                usableItems.Add(item as IUsable);
            }
        }
    }

    private void GetItemsDescription()
    {
        foreach (var item in items)
        {
            item.GetDescription();
        }
    }

    private void UseItems()
    {
        foreach (var item in usableItems)
        {
            item.Use();
        }
    }
}
```  
Now we have the item system with right solid architecture.  

---  

### Interface Segregation  
*Clients should not be forced to depend on interfaces they do not use.  
In Unity, this can mean splitting large components into smaller, more specific components with separate interfaces,  
so that clients only depend on the necessary parts of the functionality.*  
  
**Example:**  
You have a knife and pistol in your game, so it`s good think to create the IWeapon interface for them:  
```c#
public interface IWeapon
{
    public void Attack();
    public void Reload();
}
```

And implement this interface in Knife and Pistol scripts:  
```c#
public class Pistol : MonoBehaviour, IWeapon
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
```  

```c#
public class Knife : MonoBehaviour, IWeapon
{
    private void Start()
    {
        Attack();
        Reload();
    }

    public void Attack()
    {
        Debug.Log("Knife attack...");
    }

    public void Reload()
    {
        throw new System.NotImplementedException();
    }
}
```  

How can you think a knife can't reload.  
So, this is the problem of Interface Segregation principe, smth similar to Liskov Substitution.
To solve this, we can separate IWeapon to IColdWeapon and IHotWeapon interfaces for example:  
(Also you can keep the IWeapon interface with Attack method and make IReloadable interface with Reload method)  
```c#
public interface IColdWeapon
{
    public void Attack();
}
```

```c#
public interface IHotWeapon
{
    public void Attack();
    public void Reload();
}
```

```c#
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
```

```c#
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
```

Now we have all models without unusable methods.  

---

### Dependency Inversion  
*Code should depend on abstractions, not on concrete implementations.*  

*It means that you have to create abstraction classes and low/high level classes for them, avoiding dependecies between all of them.*  
*Abstraction - some model of thing that you need to implement (ex: Monster, IMonster)*  
*Low level class - object of abstraction with specific details (ex: Zombie, Vampire)*  
*Detail - specific properties, variables, etc., of the low level class (ex: zombie.speed = 10f, vampire.speed = 20f)*
*High level class - class that controlling the abstractions (ex: MonstersController)*  

**Example:**  
We have to create monsters in our game - Zombie and Vampire:  
```c#
public class Zombie : MonoBehaviour
{
    private float speed = 10f;

    public void Move()
    {
        Debug.Log($"I am Zombie and I`m moving with {speed} speed");
    }
}
```

```c#
public class Vampire : MonoBehaviour
{
    private float speed = 20f;

    public void Move()
    {
        Debug.Log($"I am Vampire and I`m moving with {speed} speed");
    }
}
```

```c#
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
```

Now, you want to add a teleportation for vampire.  
We can make like this:  
```c#
public class Zombie : MonoBehaviour
{
    private float speed = 10f;

    public void Move()
    {
        Debug.Log($"I am Zombie and I`m moving with {speed} speed");
    }
}
```

```c#
public class Vampire : MonoBehaviour
{
    private float speed = 20f;

    public void Move(float teleporationSpeed)
    {
        Debug.Log($"I am Vampire and I`m moving with {speed} speed and do teleportation with {teleportationSpeed} speed");
    }
}
```

```c#
public class MonstersController : MonoBehaviour
{
    [SerializeField] private Zombie zombie;
    [SerializeField] private Vampire vampire;

    private void Start()
    {
        zombie.Move();
        vampire.Move(30f);
    }
}
```  

To implement a teleportation for Vampire you have changed two classes and violated the Dependency Inversion principe.  
To avoid this we have to write code in such a way as to change something only in one class.  
So, let`s make an interface for monsters and call only interface objects in MonsterController.  
```c#
public interface IMonster
{
    public void Move();
}

public class MonstersController : MonoBehaviour
{
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
}
```  

After this we can make changes only in Vampire class, because the MonsterController objects have Move method without parametrs.  
```c#
public class Vampire : MonoBehaviour, IMonster
{
    private float speed = 20f;
    private float teleportationSpeed = 30f;

    public void Move()
    {
        Debug.Log($"I am Vampire and I`m moving with {speed} speed and do teleportation with {teleportationSpeed} speed");
    }
}
```
And leave our Zombie class without changes.  

Now we have implemented monsters without dependecies between their controller and details.  

---  

### Conclusion  
The importance of deep following each principle:  
S - 8/10  
O - 6/10  
L - 5/10  
I - 6/10  
D - 10/10  

Remember that sometimes following this principles are bad for the specefic case and you have to do something other way.  
It takes practice and understanding for certain tasks.  

---  

git pull the project to see how it works
