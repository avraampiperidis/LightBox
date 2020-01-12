using Firedump.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.db
{
    public class ConnectionResultSet : BaseStatus
    {
        public int exceptionType { set; get; }
        public string errorSource { set; get; }
        public int sqlErrorNum { set; get; }

        public ConnectionResultSet() : base()
        { }

        public ConnectionResultSet(Exception ex) : this()
        {
            if (ex.GetType() == typeof(ArgumentException))
            {
                setArgumenExceptiontStatus((ArgumentException)ex);
            }
            else if (ex is DbException)
            {
                setMySqlExceptionStatus((DbException)ex);
            }
            else
            {
                setUnknowGeneralExceptionStatus(ex);
            }
        }

        protected void setArgumenExceptiontStatus(ArgumentException a_ex)
        {
            setExceptionStatus(a_ex);
            exceptionType = 0;
        }

        protected void setMySqlExceptionStatus(MySqlException mex)
        {
            setExceptionStatus(mex);
            exceptionType = 1;
            errorSource = mex.Source;
            sqlErrorNum = mex.Number;
        }

        protected void setMySqlExceptionStatus(DbException mex)
        {
            setExceptionStatus(mex);
            exceptionType = 1;
            errorSource = mex.Source;
            sqlErrorNum = mex.ErrorCode;
        }

        protected void setUnknowGeneralExceptionStatus(Exception e)
        {
            setExceptionStatus(e);
            errorSource = e.Source;
        }

        private void setExceptionStatus(Exception ex)
        {
            wasSuccessful = false;
            errorMessage = ex.Message;
        }

    }
}
