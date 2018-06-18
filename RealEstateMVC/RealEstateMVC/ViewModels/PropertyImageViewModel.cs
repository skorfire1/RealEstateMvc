using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateMVC.Models;

namespace RealEstateMVC.ViewModels
{
    public class PropertyImageViewModel
    {
        public Property Property { get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
    }
}