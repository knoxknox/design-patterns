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
* [Abstract Factory](/src/GOF Patterns/AbstractFactory.cs) - Creates an instance of several families of classes
* [Builder](/src/GOF Patterns/Builder.cs) - Separates object construction from its representation
* [Factory Method](/src/GOF Patterns/Factory.cs) - Creates an instance of several derived classes
* [Prototype](/src/GOF Patterns/Prototype.cs) - A fully initialized instance to be copied or cloned
* [Singleton](/src/GOF Patterns/Singleton.cs) - A class of which only a single instance can exist

## Structural Patterns
* [Adapter](/src/GOF Patterns/Adapter.cs) - Match interfaces of different classes
* [Bridge](/src/GOF Patterns/Bridge.cs) - Separates an object’s interface from its implementation
* [Composite](/src/GOF Patterns/Composite.cs) - A tree structure of simple and composite objects
* [Decorator](/src/GOF Patterns/Decorator.cs) - Add responsibilities to objects dynamically
* [Facade](/src/GOF Patterns/Facade.cs) - A single class that represents an entire subsystem
* [Flyweight](/src/GOF Patterns/Flyweight.cs) - A fine-grained instance used for efficient sharing
* [Proxy](/src/GOF Patterns/Proxy.cs) - An object representing another object

## Behavioral Patterns
* [Chain of Responsibility](/src/GOF Patterns/ChainOfResponsibility.cs) - A way of passing a request between a chain of objects
* [Command](/src/GOF Patterns/Command.cs) - Encapsulate a command request as an object
* [Interpreter](/src/GOF Patterns/Interpreter.cs) - A way to include language elements in a program
* [Iterator](/src/GOF Patterns/Iterator.cs) - Sequentially access the elements of a collection
* [Mediator](/src/GOF Patterns/Mediator.cs) - Defines simplified communication between classes
* [Memento](/src/GOF Patterns/Memento.cs) - Capture and restore an object's internal state
* [Observer](/src/GOF Patterns/Observer.cs) - A way of notifying change to a number of classes
* [State](/src/GOF Patterns/State.cs) - Alter an object's behavior when its state changes
* [Strategy](/src/GOF Patterns/Strategy.cs) - Encapsulates an algorithm inside a class
* [Template Method](/src/GOF Patterns/TemplateMethod.cs) - Defer the exact steps of an algorithm to a subclass
* [Visitor](/src/GOF Patterns/Visitor.cs) - Defines a new operation to a class without change
