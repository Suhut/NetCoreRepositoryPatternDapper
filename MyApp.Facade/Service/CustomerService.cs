using MyApp.DAL;
using MyApp.DAL.Interface;
using MyApp.DAL.Repositories;
using MyApp.Facade.Dto;
using MyApp.Facade.Interface;
using System;

namespace MyApp.Facade.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerDtoRes GetById(Guid userId, string id)
        {
            using (DalSession dalSession = new DalSession())
            {
                //Without Transaction
                var customerRepository = new CustomerRepository(dalSession.UnitOfWork);//UoW have no effect here as Begin() is not called.
                var tm_Customer = customerRepository.GetById(id);

                var res = new CustomerDtoRes();
                res.CustomerCode = tm_Customer.CustomerCode;
                res.CustomerName = tm_Customer.CustomerName;

                return res;
            }
        }
        public CustomerDtoRes Add(Guid userId, CustomerDtoReq dtoReq)
        {
            //With transaction
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork unitOfWork = dalSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    var tm_Customer = new Tm_Customer
                    {
                        CustomerCode = dtoReq.CustomerCode,
                        CustomerName = dtoReq.CustomerName,
                        CreatedUser = userId,
                        CreatedDate = DateTime.Now,
                        ModifiedUser = userId,
                        ModifiedDate = DateTime.Now
                    };
                    var customerRepository = new CustomerRepository(unitOfWork);
                    customerRepository.Add(tm_Customer);

                    unitOfWork.Commit();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return GetById(userId, dtoReq.CustomerCode);
        }

        public CustomerDtoRes Update(Guid userId, CustomerDtoReq dtoReq)
        {
            using (DalSession dalSession = new DalSession())
            {
                //Without Transaction
                var customerRepository = new CustomerRepository(dalSession.UnitOfWork);//UoW have no effect here as Begin() is not called.
                var tm_Customer = new Tm_Customer
                {
                    CustomerCode = dtoReq.CustomerCode,
                    CustomerName = dtoReq.CustomerName,
                    ModifiedUser = userId,
                    ModifiedDate = DateTime.Now
                };
                customerRepository.Update(tm_Customer);
            }

            return GetById(userId, dtoReq.CustomerCode);
        }




    }
}
