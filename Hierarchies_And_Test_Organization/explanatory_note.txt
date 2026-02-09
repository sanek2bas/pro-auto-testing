Abstract_Test_Infrastructure_Class_Pattern
This pattern involves creating an abstract test class
that contains the necessary infrastructure common to
its derived classes. Such as class can be used in a wide
variety situations, from general setup and cleanup code 
to special assertions that are made across multiple 
test classes.
Never use more than one level of inheritance in tests.
xUnit does not use a specific [Cleanup] or [TestCleanup] attribute.

Template_Test_Class
This is an abstract class containing abstract test methods that 
must be implemented in derived classes. The driving force behind this pattern 
is to force derived classes to implement specific tests.
A template base class ensures that developers won't forget important tests.

Abstract_Test_Control_Class
The test logic is implemented in the base class itself, but contains abstract connection 
methods that must be implemented in derived classes. It is important that tests are not 
specific to one specific type of class being tested, but are written in accordance with 
the interface or base class in the production code.