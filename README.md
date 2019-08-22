<!-- pizzabox::requirements -->

# pizzabox

## architecture

+ [solution] PizzaBox.sln
  + [project] PizzaBox.Client.csproj
    + [type] Console 
  + [project] PizzaBox.Data.csproj
    + [folder] Entities
	+ [type] Library
  + [project] PizzaBox.Domain.csproj
    + [folder] Models
	+ [type] Library
  + [project] PizzaBox.Testing.csproj
    + [folder] UnitTests
	+ [type] Test Library

## requirements

### location

+ should be able to view its orders
+ should be able to view its sales
+ should be able to view its inventory
+ should be able to view its users

### order

+ should be able to view its pizzas
+ should be able to compute its cost
+ should be able to limit its cost to no more than $5000
+ should be able to limit its pizza count to no more than 100

### pizza

+ should be able to have a crust
+ should be able to have a size
+ should be able to compute its cost
+ should be able to have at least 2 default toppings
+ should be able to limit its toppings to no more than 5

### user

+ should be able to view its order history
+ should be able to only order from 1 location/day
+ should be able to only order 1 time within a 2 hour period
+ should be able to only order if an account exists

## technologies

+ .NET Core - C#
+ .NET Core - EF
+ .NET Core - xUnit
+ MS SQL Server - SQL

## timelines

### part1

+ complete the C# + xUnit portion (the domain portion)

### part2

+ complete the EF + SQL portion (the data portion)

### part3

+ complete the Console portion (the interface portion)

## showcase (as many as you can implement)

+ as a user i should be able to register
+ as a user i should be able to signin
+ as a user i should be able to view a list of locations
+ as a user i should be able to select a location
+ as a user i should be able to make an order
+ as a user i should be able to choose custom or preset pizza(s)
+ as a user i should be able to select a crust
+ as a user i should be able to select a size
+ as a user i should be able to select a set of toppings
+ as a user i should be able to preview my order
+ as a user i should be able to confirm my order
+ as a user i should be able to view my order history
+ as a user i should be able to signout
