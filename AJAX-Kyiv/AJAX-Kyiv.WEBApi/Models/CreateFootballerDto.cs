using Footballers.Application.Footballers.Commands.CreateFootballer;
using Footballers.Application.Common.Mapping;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AJAX_Kyiv.WEBApi.Models
{
    public class CreateFootballerDto : IMapWith<CreateFootballerCommand>
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string position { get; set; }
        public int number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFootballerDto, CreateFootballerCommand>()
                .ForMember(footballerCommand => footballerCommand.Name,
                opt => opt.MapFrom(footballerDto => footballerDto.Name))
                .ForMember(footballerCommand => footballerCommand.LastName,
                opt => opt.MapFrom(footballerDto => footballerDto.LastName))
                .ForMember(footballerCommand => footballerCommand.position,
                opt => opt.MapFrom(footballerDto => footballerDto.position))
                .ForMember(footballerCommand => footballerCommand.number,
                opt => opt.MapFrom(footballerDto => footballerDto.number));
        }
    }
}
