﻿using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Contracts
{
    public interface IInvoice<TVehicle>
        where TVehicle : Vehicle, IVehicle
    {
        string FirstName { get; }

        string LastName { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        TVehicle Vehicle { get; }
    }
}
