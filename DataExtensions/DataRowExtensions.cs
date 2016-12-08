using System;
using System.Data;

namespace DataExtensions
{
    public static class DataRowExtensions
    {
        public static TReturnType ConvertTo<TReturnType>(this DataRow row, string columnName, TReturnType defaultValue = default(TReturnType))
        {
            ThrowExceptionIfRowIsNull(row);

            return row[columnName] == DBNull.Value
                ? defaultValue
                : row.Field<TReturnType>(columnName);
        }

        private static void ThrowExceptionIfRowIsNull(DataRow row)
        {
            if (row == null)
            {
                throw new NullReferenceException("The DataRow was null; could not convert value to specified type.");
            }
        }
    }
}
