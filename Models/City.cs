using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPIUdemy.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; }
    }
}
