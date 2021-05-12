## User Post API

The service is responsible to manage posts for Imagegram.

Apis Provided
1. Get posts with comments (with and without pagination)

Service needs to be authenticated with the header: "X-Account-Id".

This header represents the token/session provided to user upon login as a part of authentication.

The service uses GraphQL to get the nested objects.

The example of the graph query for paginated postDetails is as below:

```json
query($id: String!, $pn: Int!, $ps: Int!) {
  postWithPaginatedComments(id: $id) {
    id
    imageUrl
    createdOn
    result(pn: $pn, ps: $ps) {
      comments {
        id
        createdOn
        content
      }
      pageInfo {
        pageNumber
        pageSize
        totalCount
      }
    }
  }
}
```
Variables:
```json
{
    "id":"1",
    "pn":5,
    "ps":2
}
```
Here pn stands pageNumber and ps stands for pageSize.</br>
The service currently consumes mock implementation of  service contracts and should get the response from actual microservices.</br>
NOTE: currently mock token authenticator is added along with all mock implementations, please add accountId header with value **_"mock"_**

----
**_Tech debts or TODOs:_**
1. To add unit testing for all implementations.
2. Actual adapter implementations to connect with the microservices (posts).
3. Mutation or support to perform other operations like delete for user.
----