## 1. Account API Service.

The service is responsible to create/manage accounts for Imagegram.

The Service is responsible to create and store the details of user and perform operations on the account.

Apis Provided
1. Create Account
2. Delete Account

Service needs to be authenticated with the header: "X-Account-Id".

This header represents the token/session provided to user upon login as a part of authentication.

## 2. Token API Service.
 The service is responsible to issue token and validate one when provided.

Apis Provided
1. Get token (create)
2. Authenticate (validate)
3. Delete Token

This authentication header used by services is provided by token service and it validates the token as well.

The service currently consumes mock implementations for stores.

----
**_Tech debts or TODOs:_**
1. To add unit testing for all implementations.
2. Actual store implementation
----

