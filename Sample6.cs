using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace csharp9.Test_PatternMatch
{

    public static class Sample6
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample6)}\n{"".PadRight(80, '_')}\n");
            var rnd = new Random().NextDouble();
            object v = rnd > 0.7
                        ? new Car { Passengers = 2 }
                        : rnd > 0.5 ? new DeliveryTruck { GrossWeightClass = 3500 }
                        : rnd > 0.1 ? new Taxi { Fares = 42 } : null!;


            Console.WriteLine($"{rnd} -> {v}");
            var c = new TollCalculator();
            Console.WriteLine($"TOLL {v} -> {c.CalculateToll(v)}");
            try
            { //? ESEMPI PIU' CONCRETI / BASICI DI UTILIZZO PATTERN MATCH + CONTROL FLOW ANALYSI
                if (!(v is not null)) throw new ArgumentNullException("EQUIVALE AL VECCHIO v == null");
                if (v is not Taxi t) throw new Exception($"{v} NON E' UN TAXI!");
                //TODO SE ARRIVO QUI t E' SICURAMENTE !=null E DI TIPO TAXI QUINDI
                Console.WriteLine($"{v == t} {v} FARE={t.Fares}"); //POSSO LEGGERE Fares
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write($"{"".PadRight(80, '=')}\n\n\n");
            }
        }


    }

    public class TollCalculator
    { //ESEMPIO PRESO DA Pattern Matching Tutorial https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/pattern-matching
        public decimal CalculateToll(object vehicle) =>
            vehicle
        switch
            {
                Car c => c.Passengers
                switch
                {
                    0 => 2.00m + 0.5m,
                    1 => 2.0m,
                    2 => 2.0m - 0.5m,
                    _ => 2.00m - 1.0m
                },

                Taxi t => t.Fares
                switch
                {
                    0 => 3.50m + 1.00m,
                    1 => 3.50m,
                    2 => 3.50m - 0.50m,
                    _ => 3.50m - 1.00m
                },

                Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
                Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
                Bus b => 5.00m,

                //TODO QUESTE ERANO LE RIGHE ORIGINALI -> ORA SFRUTTA reletional-pattern 
                // DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
                // DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
                // DeliveryTruck t => 10.00m,
                DeliveryTruck t => t.GrossWeightClass
                switch
                {
                    < 3000 => 10.00m - 2.00m,
                    >= 3000 and <= 5000 => 10.00m,
                    > 5000 => 10.00m + 5.00m,
                    // _ => 10.00m
                },

                // { } => //TODO RIGA ORIGINALE -> ORA SFRUTA SIMPLE logical-pattern 
                not null =>
                throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null =>
                throw new ArgumentNullException(nameof(vehicle))
            };
    }


}