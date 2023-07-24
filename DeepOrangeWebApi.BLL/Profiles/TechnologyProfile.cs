using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.BLL.Profiles;

public class TechnologyProfile : Profile
{
	public TechnologyProfile()
	{
		CreateMap<DAL.Entities.Technology, TechnologyReadDto>();
		CreateMap<TechnologyCreateDto, DAL.Entities.Technology>();
	}
}
