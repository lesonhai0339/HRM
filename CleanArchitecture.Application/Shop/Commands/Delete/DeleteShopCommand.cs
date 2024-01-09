using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Delete
{
    public class DeleteShopCommand : IRequest<bool>,ICommand
    {
        public DeleteShopCommand(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
