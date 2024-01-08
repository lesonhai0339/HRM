using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Create
{
    public class CreateShopCommand:IRequest<ShopDto>, ICommand
    {
        public CreateShopCommand( string name, string address , string phoneNumber ) 
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }


        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
