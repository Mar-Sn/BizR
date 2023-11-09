# BizR (WIP)
Business logic with pattern matching
                            
## How it works

First you divine you desired in and output. The input should be a 
class or record that holds all the information needed to 
make business decisions. Aka regular model + enrichment. 

```csharp
var factory = services.GetRequiredService<IBusinessFactory>();
var rules = factory
    .Create<Input, Output>()
    .RuleFor<A>(x => x
        .When(e => e.SomeCondition == true)
        .Map(e => new A("A", e.SomeCondition))
        .WithHandler<AHandler>()) 
    .RuleFor<B>(x => x
        .When(e => e.SomeCondition == false)
        .Map(_ => new B("B"))
        .WithHandler<BHandler>());
```
In this example class A and B (or record) have no relationship
and and so you are able to give model which hold no nulls, thus 
elimination the need to write complex if-else business logic.

Here is an example of the AHandler:

```csharp
private class AHandler : Handler<A, Output>
{
    public AHandler(/*MS DI enabled*/){
        
    }
    
    public override Task<Output> Handle(A input)
    {
        return Task.FromResult(new Output(Success = true));
    }
}
```