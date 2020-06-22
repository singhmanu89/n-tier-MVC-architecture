using System;
using AutoMapper;

namespace TrueForm.BusinessObjects.Extensions
{
    public static class MapperExtension
    {

        public static TDestination Map<TSource, TDestination>(this TSource source, Action<IMapperConfigurationExpression> configure)
        {
            var config = new MapperConfiguration(configure);
            var mapper = config.CreateMapper();
            var destination = mapper.Map<TDestination>(source);
            return destination;
        }

        public static TDestination Map<TSource, TDestination>(this TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>().MaxDepth(1);
            });
            var mapper = config.CreateMapper();
            var destination = mapper.Map<TDestination>(source);
            return destination;
        }


        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>().MaxDepth(1);
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
