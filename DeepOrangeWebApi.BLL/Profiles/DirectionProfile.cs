using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.BLL.Profiles;

public class DirectionProfile : Profile
{
	public DirectionProfile()
	{
		CreateMap<DAL.Entities.Direction, DirectionReadDto>();
		CreateMap<DirectionCreateDto, DAL.Entities.Direction>();
	}
}
