using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVehiclesDetail
    {
        public int Id { get; set; }

        public int? VehiclesId { get; set; }

        public string KindId { get; set; }

        public string SystemId { get; set; }

        public string TipId { get; set; }

        public string ColorId { get; set; }

        public string CalcFuelId { get; set; }

        public string FuelId { get; set; }

        public string ScaleFuel { get; set; }

        public string Model { get; set; }

        public string Quota { get; set; }

        public string QuotaAllocate { get; set; }

        public string PriceQuota { get; set; }

        public string PriceFree { get; set; }

        public string IsStatus { get; set; }

        public string Sanad { get; set; }

        public string Card { get; set; }

        public string Other { get; set; }

        public virtual TblVehicle Vehicles { get; set; }
    }
}