using AutoMapper;
using System;
using Footballers.Application.Common.Mapping;
using Footballers.Application.Footballers.Commands.UpdateFootballer;

namespace AJAX_Kyiv.WEBApi.Models
{
    public class UpdateFootballerDto : IMapWith<UpdateFootballerCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFootballerDto, UpdateFootballerCommand>()
                .ForMember(footballerCommand => footballerCommand.Id,
                    opt => opt.MapFrom(footballerDto => footballerDto.Id))
                .ForMember(footballerCommand => footballerCommand.Name,
                    opt => opt.MapFrom(footballerDto => footballerDto.Name))
                .ForMember(footballerCommand => footballerCommand.LastName,
                    opt => opt.MapFrom(footballerDto => footballerDto.LastName))
                .ForMember(footballerCommand => footballerCommand.Position,
                    opt => opt.MapFrom(footballerDto => footballerDto.Position))
                .ForMember(footballerCommand => footballerCommand.Number,
                    opt => opt.MapFrom(footballerDto => footballerDto.Number));
        }
    }
}
