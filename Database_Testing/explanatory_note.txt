Atomic updates are performed on an all-or-nothing basis. Each update in a group 
of atomic updates must either complete completely or do nothing at all.
Repositories are classes that facilitate access and modification of data in the database. 
Transaction is a class that either fully commits or fully rolls back data updates. 
This is a specialized class that uses database mechanisms to ensure the atomicity of data changes.
The transaction becomes the link between the controller and the database,
enabling atomic data modifications.

Using repositories and transactions is a good way to prevent potential data integrity issues, 
but there's a better way. The Transaction class can be updated to a unit of work.
The main advantage of the unit of work pattern over a simple transaction is the ability to defer updates.
Unlike transactions, a unit of work executes all updates at the end of a business operation, minimizing 
the duration of the underlying transaction and increasing application throughput.
Database transaction also implement the unit of work pattern.

When it comes to transaction management in integration tests, the following principle applies: 
database transactions or unit of work instances should not be reused across different sections of the test.

A shared database creates the problem of isolating integration tests from each other.
To solve this problem, you need to:
- run integration tests sequentially;
- delete remaining data between test runs.
Your tests should not depend on the state of the database. They should automatically
 restore the database to the state they require.

Cleaning up data at the beginning of a test is the best option.
It's fast, doesn't lead to inconsistent behavior, and isn't prone to accidentally skipping the cleaning phase.
You can add a base class for all integration tests and place a script for deleting test data in it.