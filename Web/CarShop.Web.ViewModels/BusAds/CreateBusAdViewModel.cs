using AutoMapper;
using CarShop.Data.Models.Ads;
using CarShop.Data.Models.Images;
using CarShop.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CarShop.Web.ViewModels.BusAds
{
    public class CreateBusAdViewModel : IHaveCustomMappings, IMapTo<BusAd>, IMapFrom<BusAd>
    {
        [Required]
        public string PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string Description { get; set; }

        [Required]
        public string DealerId { get; set; }

        [Required]
        public string BusId { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string PopulatedPlace { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CreateBusAdViewModel, BusAd>()
                .ForMember(db => db.Images,
                vm => vm
                    .MapFrom(x => x.Images
                                .Select(i => new Image() { Id = Guid.NewGuid().ToString(), Name = i.FileName, Length = i.Length })));
        }
    }
}
