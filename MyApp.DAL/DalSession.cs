using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyApp.DAL
{
    public class DalSession : IDisposable
    {
        public DalSession()
        {
            _connection = new SqlConnection("Server=SUHUT\\SQL2016;Database=DB_NETCORE_CLEAN;User Id=sa;Password=notmypassword;");
            _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }

        IDbConnection _connection = null;
        UnitOfWork _unitOfWork = null;

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }

    }
}