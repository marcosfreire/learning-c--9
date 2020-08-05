using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using toll_calculator;

/*
  Top level csharp language - playground
*/

// learning patterning matching
var car = new Car();
var car1 = new Car { Passengers = 2 };
var car2 = new Car { Passengers = 3 };
var taxi = new Taxi();
var bus = new Bus();
var truck = new DeliveryTruck();

Console.WriteLine($"The toll for a car is {TollCalculator.CalculateToll(car)}");
Console.WriteLine($"The toll for a car is {TollCalculator.CalculateToll(car1)}");
Console.WriteLine($"The toll for a car is {TollCalculator.CalculateToll(car2)}");

Console.WriteLine($"The toll for a taxi is {TollCalculator.CalculateToll(taxi)}");
Console.WriteLine($"The toll for a bus is {TollCalculator.CalculateToll(bus)}");
Console.WriteLine($"The toll for a truck is {TollCalculator.CalculateToll(truck)}");