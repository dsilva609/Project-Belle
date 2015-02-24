using AutoMapper;
using BusinessLogic.Models;
using UI.Models;

namespace UI.App_Start
{
	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.CreateMap<PlayerViewModel, Player>();
			Mapper.CreateMap<Player, PlayerViewModel>();

			Mapper.CreateMap<CardViewModel, Card>();
			Mapper.CreateMap<Card, CardViewModel>();
		}
	}
}