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
Imagine that we have two implement a Human player:  
Our Human have health and he have to move. We can realize this ideas in the same class,  
but firstly it`s inconveniently and will cause a problem if we want to make second Player, which is Ghost,    
with movement system but without health.  

So, you have to separate your class that including health and movement to give a movement component to both players:  

![Code Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S/HealthScript.png)    
![Code Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S/MoveSystemScript.png)  

Now you have flexible implementation of ideas:  

![Inspector Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S/HumanInspector.png)
![Inspector Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S/GhostInspector.png)
![Console Example Image](https://github.com/chugaister228/unity-solid-explanation/blob/main/Prewievs/S/DebugLog.png)
