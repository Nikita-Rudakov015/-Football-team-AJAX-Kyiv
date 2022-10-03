using System;
using AutoMapper;
using Footballers.Application.Common.Mapping;

namespace Footballers.Application.Footballers.Queries.GetFootballerDetails
{
    public class FootballerDetailsVm : IMapWith<AJAXKyiv.Domain.Footballer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AJAXKyiv.Domain.Footballer, FootballerDetailsVm>()
                .ForMember(footballerVm => footballerVm.Name,
                    opt => opt.MapFrom(footballer => footballer.Name))
                .ForMember(footballerVm => footballerVm.LastName,
                    opt => opt.MapFrom(footballer => footballer.LastName))
                .ForMember(footballerVm => footballerVm.Number,
                    opt => opt.MapFrom(footballer => footballer.number))
                .ForMember(footballerVm => footballerVm.Position,
                    opt => opt.MapFrom(footballer => footballer.position))
                .ForMember(footballerVm => footballerVm.Id, 
                    opt => opt.MapFrom(footballer => footballer.Id));
            profile.CreateMap<FootballerDetailsVm, AJAXKyiv.Domain.Footballer>();
        }
    }
}
