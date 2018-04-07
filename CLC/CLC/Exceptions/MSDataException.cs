using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using CLC.Controllers;

namespace CLC.Exceptions
{
    public class MSDataException : Exception
    {
        public MSDataException()
        {
        }

        public MSDataException(SqlException e)
        {
            throw e;
        }
    }
}