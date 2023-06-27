using AutoMapper;
using Basketball.Data.Entities;
using Basketball.Models.EntityModels.PlayerModels;
using Basketball.Models.EntityModels.PositionModels;
using Basketball.Models.EntityModels.TeamModels;

namespace Basketball.Models.MappingConfigurations
{
    public class Mapper : Profile
    {
        public Mapper()
        {
             CreateMap<Team,TeamCreateVM>().ReverseMap();
             CreateMap<Team,TeamListItemVM>().ReverseMap();
             CreateMap<Team,TeamDetailVM>().ReverseMap();
             CreateMap<Team,TeamUpdateVM>().ReverseMap();
         
             CreateMap<Position,PositionCreateVM>().ReverseMap();
             CreateMap<Position,PositionListItemVM>().ReverseMap();
             CreateMap<Position,PositionUpdateVM>().ReverseMap();
             
             CreateMap<Player,PlayerCreateVM>().ReverseMap();
             CreateMap<Player,PlayerListItemVM>().ReverseMap();
             CreateMap<Player,PlayerDetailsVM>().ReverseMap();
             CreateMap<Player,PlayerUpdateVM>().ReverseMap();
        }
    }
}