Design Patterns
===============

Design patterns are solutions to software design problems you find again and again in real-world application development.
Patterns are about reusable designs and interactions of objects.

The 23 Gang of Four (GoF) patterns are generally considered the foundation for all other patterns.
They are categorized in three groups: Creational, Structural, and Behavioral.
Source code for each pattern is provided in 2 forms: structural and real-world.
Structural code uses type names as defined in the pattern definition and UML diagrams.
Real-world code provides real-world programming situations where you may use these patterns.

## Creational Patterns
* [Abstract Factory](/src/GOF%20Patterns/AbstractFactory.cs) - Creates an instance of several families of classes
* [Builder](/src/GOF%20Patterns/Builder.cs) - Separates object construction from its representation
* [Factory Method](/src/GOF%20Patterns/Factory.cs) - Creates an instance of several derived classes
* [Prototype](/src/GOF%20Patterns/Prototype.cs) - A fully initialized instance to be copied or cloned
* [Singleton](/src/GOF%20Patterns/Singleton.cs) - A class of which only a single instance can exist

## Structural Patterns
* [Adapter](/src/GOF%20Patterns/Adapter.cs) - Match interfaces of different classes
* [Bridge](/src/GOF%20Patterns/Bridge.cs) - Separates an object’s interface from its implementation
* [Composite](/src/GOF%20Patterns/Composite.cs) - A tree structure of simple and composite objects
* [Decorator](/src/GOF%20Patterns/Decorator.cs) - Add responsibilities to objects dynamically
* [Facade](/src/GOF%20Patterns/Facade.cs) - A single class that represents an entire subsystem
* [Flyweight](/src/GOF%20Patterns/Flyweight.cs) - A fine-grained instance used for efficient sharing
* [Proxy](/src/GOF%20Patterns/Proxy.cs) - An object representing another object

## Behavioral Patterns
* [Chain of Responsibility](/src/GOF%20Patterns/ChainOfResponsibility.cs) - A way of passing a request between a chain of objects
* [Command](/src/GOF%20Patterns/Command.cs) - Encapsulate a command request as an object
* [Interpreter](/src/GOF%20Patterns/Interpreter.cs) - A way to include language elements in a program
* [Iterator](/src/GOF%20Patterns/Iterator.cs) - Sequentially access the elements of a collection
* [Mediator](/src/GOF%20Patterns/Mediator.cs) - Defines simplified communication between classes
* [Memento](/src/GOF%20Patterns/Memento.cs) - Capture and restore an object's internal state
* [Observer](/src/GOF%20Patterns/Observer.cs) - A way of notifying change to a number of classes
* [State](/src/GOF%20Patterns/State.cs) - Alter an object's behavior when its state changes
* [Strategy](/src/GOF%20Patterns/Strategy.cs) - Encapsulates an algorithm inside a class
* [Template Method](/src/GOF%20Patterns/TemplateMethod.cs) - Defer the exact steps of an algorithm to a subclass
* [Visitor](/src/GOF%20Patterns/Visitor.cs) - Defines a new operation to a class without change
