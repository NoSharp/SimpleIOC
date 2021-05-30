# Simple IoC
A simple IoC container for those projects where you don't want to have to add another
dependency.

## How to?
Checkout the example if you're confused.

Using the IoC Container.
```cs
    // Set an instance in the container.
    IocContainer.Instance.Set<Interface, ConcreteClass>( Constructor, Parameters );
    
    // Get the Interface you've set.
    IocContainer.Instance.Get<Interface>(); 
```
Using the constructor Injector
Example:
```cs
public class Test2 : ITest2
{

    public Test2(ITest test, string test2, string test3)
    {
        Console.WriteLine($"Test2: {test2}");
        Console.WriteLine($"Test3: {test3}");
        test.Print();
    }
}
```
When using `Set` it will infer the constructor parameters, where possible, meaning that if you 
have an interface in the container it'll grab that rather than taking it form the arguments in `Set`.