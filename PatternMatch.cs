using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace csharp9
{
    //ESEMPIO PRESO DA Pattern-Matching-Toutorial https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/pattern-matching
    public class TollCalculator
    {
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

                DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
                DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
                DeliveryTruck _ => 10.00m,

                { } =>
                throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null =>
                throw new ArgumentNullException(nameof(vehicle))
            };
    }
}