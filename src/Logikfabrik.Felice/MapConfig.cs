using System;
using AutoMapper;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using umbraco.interfaces;

namespace Logikfabrik.Felice
{
    public static class MapConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<HomePage, HomePageViewModel>()
                .MapBasePageViewModel<HomePage, HomePageViewModel>();

            Mapper.CreateMap<EatWithUsPage, EatWithUsPageViewModel>()
                .MapBasePageViewModel<EatWithUsPage, EatWithUsPageViewModel>();

            Mapper.CreateMap<LunchMenu, EatWithUsPageViewModel>();

            Mapper.CreateMap<INode, MenuItemViewModel>();

            Mapper.CreateMap<LunchMenu, MenuItemViewModel>()
                .ForMember(to => to.Name, options => options.MapFrom(from => string.Format("v. {0}", from.Week)));
        }

        public static IMappingExpression<TSource, TDestination> MapBasePageViewModel<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map)
            where TSource : BasePage
            where TDestination : BasePageViewModel
        {
            return map.ForMember(to => to.StreetAddress, options => options.ResolveUsing(ResolveStreetAddress))
                .ForMember(to => to.ZipCode, options => options.ResolveUsing(ResolveZipCode))
                .ForMember(to => to.City, options => options.ResolveUsing(ResolveCity))
                .ForMember(to => to.PhoneNumber, options => options.ResolveUsing(ResolvePhoneNumber))
                .ForMember(to => to.MapCoordinates, options => options.ResolveUsing(ResolveMapCoordinates));
        }

        private static object ResolveStreetAddress<TSource>(TSource source)
            where TSource : BasePage
        {
            return new SettingsHelper(new PageHelper()).GetStreetAddress();
        }

        private static object ResolveZipCode<TSource>(TSource source)
            where TSource : BasePage
        {
            return new SettingsHelper(new PageHelper()).GetZipCode();
        }

        private static object ResolveCity<TSource>(TSource source)
            where TSource : BasePage
        {
            return new SettingsHelper(new PageHelper()).GetCity();
        }

        private static object ResolvePhoneNumber<TSource>(TSource source)
            where TSource : BasePage
        {
            return new SettingsHelper(new PageHelper()).GetPhoneNumber();
        }

        private static object ResolveMapCoordinates<TSource>(TSource source)
            where TSource : BasePage
        {
            return new SettingsHelper(new PageHelper()).GetMapCoordinates();
        }
    }
}