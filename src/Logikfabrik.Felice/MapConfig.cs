using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Logikfabrik.Felice.Helpers;
using Logikfabrik.Felice.Models;
using Logikfabrik.Felice.ViewModels;
using Logikfabrik.Umbraco.Jet.Maps;
using umbraco.interfaces;

namespace Logikfabrik.Felice
{
    public static class MapConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<HomePage, HomePageViewModel>()
                .MapBasePageViewModel<HomePage, HomePageViewModel>();

            Mapper.CreateMap<FindUsPage, FindUsPageViewModel>()
                .MapBasePageViewModel<FindUsPage, FindUsPageViewModel>()
                .ForMember(to => to.OpeningHoursWeek, options => options.ResolveUsing(ResolveCurrentWeek));

            Mapper.CreateMap<EatWithUsPage, EatWithUsPageViewModel>()
                .MapBasePageViewModel<EatWithUsPage, EatWithUsPageViewModel>();

            Mapper.CreateMap<LunchMenu, LunchMenuViewModel>();
            Mapper.CreateMap<MenuDish, MenuDishViewModel>();
            Mapper.CreateMap<INode, MenuItemViewModel>();

            Mapper.CreateMap<LunchMenu, MenuItemViewModel>()
                .ForMember(to => to.Name, options => options.MapFrom(from => string.Format("v. {0}", from.Week)))
                .ForMember(to => to.Url, options => options.ResolveUsing(ResolveLunchMenuUrl));

            Mapper.CreateMap<Hours, HoursViewModel>();
            Mapper.CreateMap<GeoCoordinates, GeoCoordinatesViewModel>();
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

        private static object ResolveLunchMenuUrl<TSource>(TSource source)
            where TSource : LunchMenu
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var helper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            return helper.RouteUrl("ViewLunchMenu", new RouteValueDictionary(new { @year = source.Year, @week = source.Week }));
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
            return Regex.Replace(new SettingsHelper(new PageHelper()).GetPhoneNumber(), @"[^\d]", string.Empty);
        }

        private static object ResolveMapCoordinates<TSource>(TSource source)
            where TSource : BasePage
        {
            var coordinates = new SettingsHelper(new PageHelper()).GetMapCoordinates();

            return Mapper.Map<GeoCoordinatesViewModel>(coordinates);
        }

        private static object ResolveCurrentWeek<TSource>(TSource source)
            where TSource : BasePage
        {
            return new DateHelper().GetWeekOfYearISO8601(DateTime.Now);
        }
    }
}