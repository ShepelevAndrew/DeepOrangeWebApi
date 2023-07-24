using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.BLL.Profiles;

public class ProfileProfile : Profile
{
	public ProfileProfile()
	{
		CreateMap<DAL.Entities.Profile, ProfileReadDto>();
		CreateMap<ProfileCreateDto, DAL.Entities.Profile>();
	}
}