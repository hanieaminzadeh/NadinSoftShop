using NadinSoftShop.Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoftShop.Domain.Product.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string ManufactureEmail { get; set; }

        public string ManufacturePhone { get; set; }

        public int UserId { get; set; }
    }
}
