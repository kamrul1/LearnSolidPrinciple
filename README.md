# Learn Solid Principle

When writing code, it should not be over engineered to be SOLID from start.  Instead
the **Pain Driven Development** is recommended i.e. code the functionality how 
you know best works in code.  Aferwards, apply SOLID to the code. 


This is project where I follow along the practices from the excellent PluralSight
course by Aralis.  The repo that was used in the course can be found at Github:

[ardalis/SolidSample](https://github.com/ardalis/SolidSample)

### Setup

I copied the basic code at the begin of the course as my begining master branch.


## Applying Single Responsibility Principle

Element to look for:
- logging - ConsoleLogger class
- presistant - PolicySource class
- Encoding format -- PolicySerializer class

These only do one thing.

These classes are delegated the task.  RatingEngine class no longer needs to
concern its self with detail of how the work is done.

Naming these classes are easy when they do only one thing.

Each of these classes are also easily tested.

## Applying Open/Closed Principle

This example make it possible to extend the functionality without changing it.
In this case ***PolicyType.Flood*** is introduced.  This is to show that if
other policy types are added how it could be added without change to existing.

Each policy is given its rater, which is just the content of the switch
statement.  As they all share the same method signature, it makes sense 
to use an **abstract class** for
them i.e. PolicyRaterAbstract class.

Now that classes all share their initialisation, it's good at this point to 
use a **PolicyRaterFactory class**.

```
public class PolicyRaterFactory
{
    public PolicyRaterAbstract Create(Policy policy, RatingEngine engine)
    {
        switch (policy.Type)
        {
            case PolicyType.Auto:
                return new AutoPolicyRater(engine, engine.Logger);

            case PolicyType.Flood:
                return new FloodPolicyRater(engine, engine.Logger);

            case PolicyType.Land:
                return new LandPolicyRater(engine, engine.Logger);

            case PolicyType.Life:
                return new LifePolicyRater(engine, engine.Logger);

            default:
                // currently this can't be reached 
                return new UnknownPolicyRater(engine, engine.Logger);
        }
    }
}
```

Using string pattern matching, reflection can used used to refactor this class
further.

```
namespace LearnSolidPrinciple.Rating
{
    public class PolicyRaterFactory
    {
        public PolicyRaterAbstract Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (PolicyRaterAbstract)Activator.CreateInstance(
                    Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
```
Of particular interest is the line: **Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater")**, it
is comprised of the namespace and the name of the class (pattern matached from Policy.Type)

As the return could be a null, we do hower need to do a check on it on return to RatingEngine class

```
var policyRaterAbstract = factory.Create(policy, this);
policyRaterAbstract?.Rate(policy);
```

### Closed for modification using guard clauses

One way to not allow modification is through guard clauses.  As shown in the 
package http://github.com/ardalis/guardclauses.  You can extend using your own
guard clauses.

## Liskov Substitution Principle

How to detect violations:
- Type checking with **is** or **as** in polymorphic code
- Null checks, like type checks
- NotImplementedException, class can't be substituted 

Any time you are using null checks, you are treating that object differently
from others.  This violates the principle.

```
if(rater==null)
{
    Logger.log("Unknown policy type");
}
else
{
    rater.Rate(policy);
}
```

We can overcome this viloation by using the **Null object Pattern**.  instead of
returning null when the object can't be created
```
public PolicyRaterAbstract Create(Policy policy, RatingEngine engine)
{
    try
    {
        return (PolicyRaterAbstract)Activator.CreateInstance(
            Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
                new object[] { engine, engine.Logger });
    }
    catch
    {
        return null;
    }
}
```
when the object can't be created, we return an UnknownPolicyRater class.
```
try
{
    return (PolicyRaterAbstract)Activator.CreateInstance(
        Type.GetType($"LearnSolidPrinciple.Rating.{policy.Type}PolicyRater"),
            new object[] { engine, engine.Logger });
}
catch
{
    return new UnknownPolicyRater(engine, engine.Logger);
}
```
The UnknownPolicyRater details means that we do not need to deal with null checking.


## Interface Segregation Principle

How to identify:
- Large intefaces, code uses a small subset of it
- NotImplementedException

One way to address large interfaces is to use Adaptor pattern.  The 
[Adapter design pattern](https://www.dofactory.com/net/adapter-design-pattern) 
converts the interface of a class into another interface clients expect. 
This design pattern lets classes work together that couldn‘t otherwise 
because of incompatible interfaces.

The problem example here is the DefaultRatingContext class, which has become bloated with
lots of functions as it has interfaces for Logger, Pressistance, Encoding.

IRatingContext is to big and not all methods in the DefaultRatingContact class
implement all its functionality.

```
public string LoadPolicyFromURI(string uri)
{
    throw new NotImplementedException();
}

public void Log(string message)
{
    new ConsoleLogger().Log(message);
}
```


## Dependency Inversion Principle

Mostly to do with compile time dependencies.  This is seperating high level 
concern from low level concerns

High Level Dependencies:
- More abstract and interfaces - define a contract
- Business rules
- Process oriented
- Further away from input/output e.g. form and buttons
- Model


Low levels code is details, it's  about how you interact with a specific system and hardware. 
These are things you can instatiate. 

Low Level Detail dependencies:
- "Plumbing" code connects
- Database
- File System
- Email
- Web API (hosting)
- Configuration details (reading from a file)
- Time (reading from external system)
- Hidden - using static or new() glue keywords 

Start by decoupling DafaultRatingContext class from it's blouted methods
and remove it from RatingEngine class.




This example introduces another logger, this time FileLogger class.  

We could use constructor chaining for both overloads to work with legacy code

```
public RatingEngine(): this(new ConsoleLogger())
{
}

public RatingEngine(ILogger logger)
{
    Context.Engine = this;
    this.logger = logger;
}

```
However, this still keeps a dependency.  So we move the new() instantiation up
to the Program class and pass it in.


Organising the files after refactoring.  Feature folder organisation as in 
clean architecture:

- **Core**: business logic without dependencies on external logic
  - Interfaces: this could also be called abstractions
  - Model: policy types
  - Raters: business logic, including rating engine
- **Infrastructure**: where specific implementation details e.g. file system
  - Logger
  - PolicySources
  - Serializer
- **UI**: entry point into the system























