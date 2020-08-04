using MyApp.Facade.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Facade.Interface
{
    public interface ICustomerService
    {
        public CustomerDtoRes GetById(Guid userId, string id);
        public CustomerDtoRes Add(Guid userId, CustomerDtoReq dtoReq);
        public CustomerDtoRes Update(Guid userId, CustomerDtoReq dtoReq); 

    }
}
