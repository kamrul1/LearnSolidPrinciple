# Learn Solid Principle

This is project where I follow along the practices from the excellent PluralSight
course by Aralis.  The repo that was used in the course can be found at Github:

[ardalis/SolidSample](https://github.com/ardalis/SolidSample)

# Setup

I copied the basic code at the begin of the course as my begining master branch.


### Applying Single Responsibility Principle

Element to look for:
- logging - ConsoleLogger class
- presistant - PolicySource class
- Encoding format -- PolicySerializer class

These only do one thing.

These classes are delegated the task.  RatingEngine class no longer needs to
concern its self with detail of how the work is done.

Naming these classes are easy when they do only one thing.

Each of these classes are also easily tested.

### Applying Open/Closed Principle

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









