namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO;
    using CarDealer.DTO.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<DtoSupplier, Supplier>();
            this.CreateMap<DtoParts, Part>();
        }
    }
}
