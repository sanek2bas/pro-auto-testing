Good unit-test should have the following four attriburtes:
- bug protection;
- resistance to refactoring;
- quick feedback
- easy for support.

The First Aspect: Bug Protection
Typically, such errors occur after changes are made to the code—usually after writing a new function.
As a general rule, the more tests a code runs, the higher the probability of introducing 
a bug (assuming there is one, of course). Of course, a test should also have a relevant
set of assertions; simply selecting the code is sufficient.
To maximize the bug protection metric, a test should execute the maximum amount of code possible.

The Second Aspect: Resilience to Refactoring
Refactoring is a modification of existing code without changing its observable behavior.
False alarm is test indicates that functionality doesn't work, when in reality
everything works as expected. Such false pisitives typically occur during code
refactoring, when you change the implementation but leave the applications's
behaviour unchanged. Hence the name of this attribute: refactoring resistance.
To evaluate a test's refactoring resistance, look at how many false positives
it producesl - the fewer, the better.
The more closely a test is tied to the implmentation details of the system
under test (SUT), the more false positives it generates. The only way to
reduce the number of false positives is to decouple the test from the 
implementation details of the SUT. A test should verify the end result—
the observable behavior of the SUT, not the actions it takes to achieve that result. 
Tests should approach the SUT from the end user's perspective and verify 
only the result that is meaningful to that user. 
Everything else should be discarded.

MessageRenderer_Uses_Correct_Sub_Renderers - test checks that all subgenerators
are of the expected type and are present in the correct order. Any attempt at 
this kind of test will fail, even if the final result remains unchanged.
This is because the test is tied to the implementation dedtails of the system
under test, not to the output it generates.

Rendering_A_Message - this test treats the MessageRenderer as a "black box" and 
is only interested in its observable behavior. This makes the test much more resilient 
to refactoring—it doesn't care what changes are made to the system under test, 
as long as the resulting HTML remains unchanged.

The Third Aspect: Fast Feedback
Quickly executed tests have a significant impact on feedback. 
Ideally, tests begin alerting you to errors immediately after editing them,
reducing the cost of fixing them to almost nothing.

The Fourth Aspect: Ease Of Support
How difficult is the test to understand. This component is related to the size of the test. 
The less code in a test, the easier it is to read. Small tests are also easier to change if necessary.
The quality of test code is no less important than the quality of production code.
How difficult is the test to run. If a test relies on out-of-process dependencies, 
you will have to spend time maintaining these dependencies: restarting the database server,
troubleshooting network issues.