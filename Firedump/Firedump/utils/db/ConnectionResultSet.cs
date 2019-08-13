using Firedump.models.pojos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.databaseUtils
{
    public class ConnectionResultSet : BaseStatus
    {
        public int exceptionType { set; get; }
        public string errorSource { set; get; }
        public int sqlErrorNum { set; get; }

        public ConnectionResultSet():base()
        {}

        public ConnectionResultSet(Exception ex):this()
        {
            if(ex.GetType() == typeof(ArgumentException))
            {
                this.setArgumenExceptiontStatus((ArgumentException)ex);
            } else if(ex is DbException)
            {
                this.setMySqlExceptionStatus((DbException)ex);
            } else
            {
                this.setUnknowGeneralExceptionStatus(ex);
            }
        }

        protected void setArgumenExceptiontStatus(ArgumentException a_ex)
        {
            this.setExceptionStatus(a_ex);
            this.exceptionType = 0;
        }

        protected void setMySqlExceptionStatus(MySqlException mex)
        {
            this.setExceptionStatus(mex);
            this.exceptionType = 1;
            this.errorSource = mex.Source;
            this.sqlErrorNum = mex.Number;
        }

        protected void setMySqlExceptionStatus(DbException mex)
        {
            this.setExceptionStatus(mex);
            this.exceptionType = 1;
            this.errorSource = mex.Source;
            this.sqlErrorNum = mex.ErrorCode;
        }

        protected void setUnknowGeneralExceptionStatus(Exception e)
        {
            this.setExceptionStatus(e);
            this.errorSource = e.Source;
        }

        private void setExceptionStatus(Exception ex)
        {
            this.wasSuccessful = false;
            this.errorMessage = ex.Message;
        }
        
    }
}
