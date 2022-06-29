## Prime Number Decomposition API

The goal of this task is to implement a Prime Number Decomposition API using a
gRPC Server Streaming Service.

* The function takes a Request message that contains a number to decompose into
prime numberes.

* The server responds through a server streaming gRPC with the decomposed prime
factors of the number given.

* Implementation of the proto files is shared on both client and server (could be
a bit better)



## Results

```
# Server running ...
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5211
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/diego_canizales/Projects/grpc-csharp-udemy/exercises/PrimeNumberDecomposition/PrimeNumberDecomposer/
The server received the request:
{ "number": 10 }
The server received the request:
{ "number": 252 }
The server received the request:
{ "number": 10052 }


# Client responses

## 10
Client connected successfully
Reply: 2
Reply: 5

## 252
Client connected successfully
Reply: 2
Reply: 2
Reply: 3
Reply: 3
Reply: 7

## 10052
Client connected successfully
Reply: 2
Reply: 2
Reply: 7
Reply: 359
```
