using MyApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MyApp.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        IUnitOfWork _unitOfWork = null;
        public CustomerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Add(Tm_Customer entity)
        {
            _unitOfWork.Connection.Insert(entity, _unitOfWork.Transaction);
            return entity.CustomerCode;
        }

        public string Update(Tm_Customer entity)
        {
            _unitOfWork.Connection.Update(entity, _unitOfWork.Transaction);
            return entity.CustomerCode;
        }

        public Tm_Customer GetById(string id)
        {
            return _unitOfWork.Connection.Get<Tm_Customer>(id, _unitOfWork.Transaction);
        }

    }
}
