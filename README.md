# C# People

A People API broken out into the different layers typical in an application.

## Setup

This should run out of the box

## Layers

Typical layers in the app consist off:

- Data layer consisting of a db which is currently set to an EntityFrameworkCore.InMemory instance

- Repository which is generic
- Models containing any Domain models
- API which contains the DTOs and Endpoints

