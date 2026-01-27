An isolation framework is a set of programmable APIs that make creating mock objects much easier, 
faster, and more concise than doing it manually. A well-designed isolation framework can free a developer 
from having to write the same code over and over again to assert or simulate object interactions. 
And if the framework is designed very well, it can be used to create tests that will last for years,
without forcing the developer to return to them after the slightest change to the production code.

A dynamic fake object is a stub or mock created at runtime without the need to manually code the implementation.

Analyze_TooShortFileName_CallLogger - a handwritten forgery created without the use of an insulating frame.

Analyze_TooShortFileName_CallLogger_With_NSub - test with dynamic dummy object.
The last line uses an extension method provided by NSub instead of the usual assertion. 
The ILogger interface doesn't have a method named Received(). Using this method, we assert that this fake 
object was actually called (and therefore is conceptually a fake). It returns an object of the same type 
it was called on, but its methods are used to make assertions.

Returns_ByDefault_WorksForHardCodedArgument - but what if we don't care about the argument? 
From a maintainability perspective, it would be better to always return a specific fake value,
no matter what the argument, because then, no matter how the internal structure of the production code changes,
the test will still pass, even if the production code calls the method several times. 
Clarity will also be improved, because now the reader of the test doesn't know whether a specific file
name is important. If you can make their life easier by not forcing them to absorb unnecessary information,
then they'll be able to maintain your code more easily.

Returns_ByDefault_WorksForHardCodedArgument_2 - the Arg class is used to indicate that this fake value 
should be returned for any input argument. Such argument matchers are widely used in isolation frameworks
to specify the order in which arguments are processed.

Analyze_LoggerThrows_CallsWebService
Analyze_LoggerThrows_CallsWebService_With_NStub
If the logger object raises an exception, the web service must be notified.

Analyze_LoggerThrows_CallsWebServiceWithNSubObject
Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare
Comparison of objects and properties

Events are a two-way street, and they can be tested in two directions:
- check that someone is listening to the event
- check that someone is generating the event
To test, it's best to ensure that the listener object actually does something in response to the generated event. 
If the listener hasn't subscribed to the event, there will be no visible change in behavior.
Ctor_WhenViewIsLoaded_CallsViewRender and Ctor_WhenViewhasError_CallsLogger - testing the event listener.

EventFiringManual - using an anonymous delegate to subscribe to an event