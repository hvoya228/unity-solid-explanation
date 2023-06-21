# Explanation  

### What is SOLID?  
SOLID - is set of rules, by following which you will have flexible and easier to understand project.    
Following solid rules is great for team project to have understanding the code of each other,  
without studying the approach to each individual's work.  
Also you will get a flexible project to adding smth new in the future and will avoid many bugs during development.  

### Single responsibility  
Each object or script should have a single responsibility.  
This helps keep your code clean and easy to understand.  
Avoid having overloaded scripts that do too many different things.  
Instead, separate functionality into individual scripts with clear responsibilities.  

Example:  
Imagine that we have two implement to Players in project:    

![Hierarchy Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S-PlayersObjects.png)

Our Player have health and he have to move. We can realize this ideas in the same class,  
but firstly it`s inconveniently and will cause a hardcoding if we want to make two Players with diferent movement system.  

We have to realize two players:    
one of them have health and keyboard movement system,  
other also have health but mouse movement system.  

So, you have to separate your class that including health and movement to give a health component to both players with diferent movement systems:  

![Code Example Image]()
![Code Example Image]()
![Code Example Image]()

Now you have flexible implementation of ideas:  

![Inspector Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S-Player1Inspector.png)
![Inspector Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S-Player2Inspector.png)
![Console Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S-DebugLog.png)
