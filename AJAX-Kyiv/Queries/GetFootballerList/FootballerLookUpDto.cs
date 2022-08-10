using System;
using Footballers.Application.Common.Mapping;
using AutoMapper;


namespace Footballers.Application.Footballers.Queries.GetFootballerList
{
    public class FootballerLookUpDto : IMapWith<AJAXKyiv.Domain.Footballer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AJAXKyiv.Domain.Footballer, FootballerLookUpDto>()
                .ForMember(footballerDto => footballerDto.Id,
                    opt => opt.MapFrom(footballer => footballer.Id))
                .ForMember(footballerDto => footballerDto.Name,
                    opt => opt.MapFrom(footballer => footballer.Name))
                .ForMember(footballerDto => footballerDto.LastName,
                    opt => opt.MapFrom(footballer => footballer.LastName));
        }
    }
}
