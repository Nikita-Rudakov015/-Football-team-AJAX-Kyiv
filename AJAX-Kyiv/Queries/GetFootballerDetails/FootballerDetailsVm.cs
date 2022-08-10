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
        public int number { get; set; }
        public string position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AJAXKyiv.Domain.Footballer, FootballerDetailsVm>()
                .ForMember(footballerVm => footballerVm.Name,
                    opt => opt.MapFrom(note => note.Name))
                .ForMember(footballerVm => footballerVm.LastName,
                    opt => opt.MapFrom(note => note.LastName))
                .ForMember(footballerVm => footballerVm.number,
                    opt => opt.MapFrom(note => note.number))
                .ForMember(footballerVm => footballerVm.position,
                    opt => opt.MapFrom(note => note.position))
                .ForMember(footballerVm => footballerVm.Id,
                    opt => opt.MapFrom(footballer => footballer.Id));
        }
    }
}
