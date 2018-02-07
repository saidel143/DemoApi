using AutoMapper;
using Portales.Dal.Model;
using Portales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portales.Api
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Resume, opt => opt.MapFrom(src => src.FileClient
                .FirstOrDefault(f => f.FileType == FileType.Resume).FileName))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.FileClient
                .FirstOrDefault(f => f.FileType == FileType.Avatar).FileName))
                .ReverseMap();
            });
        }
    }
}