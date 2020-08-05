using CommercialRegistration;
using ConsumerVehicleRegistration;
using Learning.CSharp.Nove.Common;
using LiveryRegistration;
using System;

namespace Learning.CSharp.Nove.PatternMatcingSamples
{
    public enum LifeStage
    {
        Prenatal,
        Infant,
        Toddler,
        EarlyChild,
        MiddleChild,
        Adolescent,
        EarlyAdult,
        MiddleAdult,
        LateAdult
    }

    public class LearningPatternMatching
    {
        public static LifeStage LifeStageAtAge(int age)
        {
            var retorno = age switch
            {
                < 0 => LifeStage.Prenatal,
                < 2 => LifeStage.Infant,
                < 4 => LifeStage.Toddler,
                < 6 => LifeStage.EarlyChild,
                < 12 => LifeStage.MiddleChild,
                < 20 => LifeStage.Adolescent,
                < 40 => LifeStage.EarlyAdult,
                < 65 => LifeStage.MiddleAdult,
                _ => LifeStage.LateAdult,
            };

            PrinterHelper.Print(retorno.ToString());

            return retorno;
        }
    }
}

namespace ConsumerVehicleRegistration
{
    public class Car
    {
        public int Passengers { get; set; }
        public int Teste { get; set; }
    }
}

namespace CommercialRegistration
{
    public class DeliveryTruck
    {
        public int GrossWeightClass { get; set; }
    }
}

namespace LiveryRegistration
{
    public class Taxi
    {
        public int Fares { get; set; }
    }

    public class Bus
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }
    }
}

namespace toll_calculator
{
    public class TollCalculator
    {
        public static decimal CalculateToll(object vehicle) => vehicle switch
        {
            Car { Passengers: 0 } => 2.00m + 0.50m,
            Car { Passengers: 1 } => 2.0m,
            Car { Passengers: 2 } => 2.0m - 0.50m,
            Car => 2.00m - 1.0m,

            Taxi { Fares: 0 } => 3.50m + 1.00m,
            Taxi { Fares: 1 } => 3.50m,
            Taxi { Fares: 2 } => 3.50m - 0.50m,
            Taxi => 3.50m - 1.00m,

            Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
            Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
            Bus => 5.00m,

            DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
            DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
            DeliveryTruck => 10.00m,

            { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
            null => throw new ArgumentNullException(nameof(vehicle))
        };

        public decimal CalculateToll2(object vehicle) => vehicle switch
        {
            Car c => c.Passengers switch
            {
                0 => 2.00m + 0.5m,
                1 => 2.0m,
                2 => 2.0m - 0.5m,
                _ => 2.00m - 1.0m
            },

            Taxi t => t.Fares switch
            {
                0 => 3.50m + 1.00m,
                1 => 3.50m,
                2 => 3.50m - 0.50m,
                _ => 3.50m - 1.00m
            },

            Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
            Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
            Bus b => 5.00m,

            DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
            DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
            DeliveryTruck t => 10.00m,

            { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
            null => throw new ArgumentNullException(nameof(vehicle))
        };

        private bool IsWeekDay(DateTime timeOfToll) => timeOfToll.DayOfWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => true
        };

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private TimeBand GetTimeBand(DateTime timeOfToll) => timeOfToll.Hour switch
        {
            < 6 => TimeBand.Overnight,
            < 10 => TimeBand.MorningRush,
            < 16 => TimeBand.Daytime,
            < 20 => TimeBand.EveningRush,
            _ => TimeBand.Overnight
        };

        public decimal PeakTimePremiumFull(DateTime timeOfToll, bool inbound) => (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
        {
            (true, TimeBand.MorningRush, true) => 2.00m,
            (true, TimeBand.MorningRush, false) => 1.00m,
            (true, TimeBand.Daytime, true) => 1.50m,
            (true, TimeBand.Daytime, false) => 1.50m,
            (true, TimeBand.EveningRush, true) => 1.00m,
            (true, TimeBand.EveningRush, false) => 2.00m,
            (true, TimeBand.Overnight, true) => 0.75m,
            (true, TimeBand.Overnight, false) => 0.75m,
            (false, TimeBand.MorningRush, true) => 1.00m,
            (false, TimeBand.MorningRush, false) => 1.00m,
            (false, TimeBand.Daytime, true) => 1.00m,
            (false, TimeBand.Daytime, false) => 1.00m,
            (false, TimeBand.EveningRush, true) => 1.00m,
            (false, TimeBand.EveningRush, false) => 1.00m,
            (false, TimeBand.Overnight, true) => 1.00m,
            (false, TimeBand.Overnight, false) => 1.00m,
            _ => throw new NotImplementedException(),
        };
    }
}