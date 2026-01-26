Interaction testing is testing how an object sends messages to other objects (calls their methods). 
This type of testing is used when the end result of a unit of work is a call to another object.
Interaction testing can be considered action-driven. This means that it tests what action an object 
takes (for example, sending a message to another object). Interaction testing should always be a last resort.
This is a very important point. First, make sure that you cannot test a unit of work based on the results 
of the first two types (value and state), because interaction tests are much more complex. 
But sometimes, as when calling a third-party logging tool, the interactions between objects are the end result. 
In this case, there is nothing to do – you have to test the interaction itself.

A mock object is a dummy object that determines whether a standalone test passes or fails. 
It does this by verifying that the object under test invoked the mock object as expected. 
Typically, each test uses no more than one mock object.

Analyze_TooShortFileName_CallsWebService - is testing the interaction between LogAnalyzer and a web service. 
Also note that the assertion is moved outside the mock object's code. There are two reasons for this:
 - we'd like to be able to reuse this mock object in other tests that make different assertions about the message.
 - if the assertion were placed inside a handwritten mock class, the reader of the test wouldn't be able 
   to understand what was being asserted. We've removed essential information from the test code, making it 
   less readable and maintainable.

Analyze_WebServiceThrows_SendsEmail - this test uses two fake objects. One is a fake mail service, 
which we'll use to verify that the correct parameters were passed to the mail service. 
The second is a stub, which will allow us to simulate an exception raised by the web service.
It's a stub because we won't be using the fake web service to verify the test's outcome;
it's only needed to ensure its functionality. The mail service is a stub because we're making 
an assertion about the correctness of its call.