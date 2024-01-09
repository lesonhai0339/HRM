using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Update
{
    public class UpdateShopCommand : IRequest<ShopDto>, ICommand
    {
        public UpdateShopCommand(Guid id, string name, string address, string phoneNumber)
        {
            Id = id; 
            Name = name; 
            Address = address; 
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
