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
        public static void RegisterMaps(SettingsHelper settingsHelper)
        {
            if (settingsHelper == null)
                throw new ArgumentNullException("settingsHelper");

            Mapper.CreateMap<HomePage, HomePageViewModel>()
                .MapBasePageViewModel<HomePage, HomePageViewModel>(settingsHelper);

            Mapper.CreateMap<EatWithUsPage, EatWithUsPageViewModel>()
                .MapBasePageViewModel<EatWithUsPage, EatWithUsPageViewModel>(settingsHelper);

            Mapper.CreateMap<LunchMenu, EatWithUsPageViewModel>();

            Mapper.CreateMap<INode, MenuItemViewModel>();

            Mapper.CreateMap<LunchMenu, MenuItemViewModel>()
                .ForMember(to => to.Name, options => options.MapFrom(from => string.Format("v. {0}", from.Week)));
        }

        public static IMappingExpression<TSource, TDestination> MapBasePageViewModel<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map, SettingsHelper settingsHelper)
            where TSource : BasePage
            where TDestination : BasePageViewModel
        {
            if (settingsHelper == null)
                throw new ArgumentNullException("settingsHelper");

            var mapCoordinates = settingsHelper.GetMapCoordinates();

            if (mapCoordinates != null)
                map =
                    map.ForMember(to => to.Lat, options => options.UseValue(mapCoordinates.Lat))
                        .ForMember(to => to.Lng, options => options.UseValue(mapCoordinates.Lng));

            return map.ForMember(to => to.StreetAddress, options => options.UseValue(settingsHelper.GetStreetAddress()))
                .ForMember(to => to.ZipCode, options => options.UseValue(settingsHelper.GetZipCode()))
                .ForMember(to => to.City, options => options.UseValue(settingsHelper.GetCity()))
                .ForMember(to => to.PhoneNumber, options => options.UseValue(settingsHelper.GetPhoneNumber()));
        }
    }
}