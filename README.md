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








