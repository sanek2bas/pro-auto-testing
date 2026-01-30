There are three styles of unit testing:
- output testing;
- state testing;
- interaction testing.

Discount_Of_Two_Products 
Output testing, in which input data is fed to the 
system under test (SUT) and the resulting output is verified. 
This style of unit testing is only applicable to code that does not modify global or internal state, 
so the only component that needs to be verified is its return value.

Adding_A_Product_To_An_Order
Stateful testing in which the test verifies the state of the system after 
an operation has completed. The term "state" in this style of testing can refer to the state of the system
under test itself, one of its collaborators, or an out-of-process dependency—for example, a database or file system.

Sending_A_Greetings_Email
The third style of unit testing is interaction testing. This style uses mocks to verify interactions between 
the system under test and its collaborators.

AuditManager - is good example of using the interface for separation of logic from the file system.
It's worth noting that in this particular case, using a mock is justified. The application creates 
files that are visible to end users (it's assumed that users can read the files using another program, 
whether a specialized program or the standard notepad.exe).

AuditManager2 - is example with functional architecture. It helps achieve this separation by separating impacting 
factors into business operations. This approach maximizes the amount of code written in a purely functional 
style while minimizing code that deals with side effects. A functional architecture divides all code into two categories:
a functional core and a mutable shell. The functional core makes decisions. The mutable shell provides input to the 
functional core and transforms the core's decisions into side effects.

The difference between functional and hexagonal architectures is evident in their attitudes toward side effects. 
A functional architecture pushes all side effects beyond the boundaries of the domain layer. On the other hand,
a hexagonal architecture tolerates side effects produced by the domain layer, provided they are limited to that domain layer. 
A functional architecture can be viewed as a hexagonal architecture taken to its extreme.

Choosing between a functional and a more traditional architecture means a tradeoff between performance and code maintainability.
A functional architecture sacrifices performance for improved maintainability.
Using a functional architecture isn't justified for every codebase. Always apply a functional architecture strategically, 
taking into account the complexity and importance of your system. If your codebase is too simple or unimportant, 
the initial investment required for a functional architecture won't be worth it.