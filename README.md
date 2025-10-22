# C# People

A People API broken out into the different layers typical in an application.

## Setup

This should run out of the box

## Layers

Application is split into the following layers:

| Layer      | Description                                                                 |
|------------|-----------------------------------------------------------------------------|
| Data       | Database layer using EntityFrameworkCore.InMemory                          |
| Repository | Generic repository abstraction                                              |
| Models     | Contains domain models                                                      |
| API        | Contains DTOs and endpoint definitions                                      |
| RMQReceive | Polls RabbitMQ to output messages to Console                                |
| RMQSend    | Captures messages from Console to send to RabbitM                           |

## Branches

The following branches exist on this repository:

| Branch                    | Description                          |
|--------------------------|--------------------------------------|
| main                     | Pure vanilla code                    |
| feature/inputoutputpattern | Design pattern for input/output     |
| feature/masstransitrabbitmq | Integrates API with MassTransit and RabbitMQ |
