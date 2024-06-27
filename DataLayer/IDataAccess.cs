﻿using System.Data;
using System.Data.Common;
namespace ProductApp_1165395.DataLayer
{
    public interface IDataAccess
    {
        // last three parameters are optional and useed if a transaction is involved
        object GetSingleAnswer(string sql, List<DbParameter> PList, DbConnection conn = null,
        DbTransaction sqtr = null, bool bTransaction = false);
        DataTable GetManyRowsCols(string sql, List<DbParameter> PList, DbConnection conn = null,
        DbTransaction sqtr = null, bool bTransaction = false);
        int InsertUpdateDelete(string sql, List<DbParameter> PList, DbConnection conn = null,
        DbTransaction sqtr = null, bool bTransaction = false);
    }
}