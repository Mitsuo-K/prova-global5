using System.Data;
using System.Data.OleDb;
using System.Numerics;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace Api.Model.StoreProcedure
{
    public class StoredProcedureBaseModel
    {
        public List<SqlParameter> ReturnParameterList()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            foreach (var prop in GetType().GetProperties())
            {
                var attribute = (SqlParameterAttribute)prop.GetCustomAttributes(typeof(SqlParameterAttribute), false).FirstOrDefault();

                if (attribute != null && attribute.IsParameter)
                {
                    SqlParameter parameter;

                    var paramName = "@" + prop.Name;
                    var propValue = prop.GetValue(this, null);

                    switch (prop.PropertyType.Name)
                    {
                        case "String":
                            parameter = new SqlParameter(paramName, propValue != null && (string)propValue != string.Empty ? Convert.ToString(propValue) : DBNull.Value);
                            break;
                        case "Int32":
                            parameter = new SqlParameter(paramName, propValue != null && (int)propValue != int.MinValue ? Convert.ToInt32(propValue) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.Int;
                            break;
                        case "Int64":
                            parameter = new SqlParameter(paramName, propValue != null && (long)propValue != long.MinValue ? Convert.ToInt64(propValue) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.BigInt;
                            break;
                        case "BigInteger":
                            parameter = new SqlParameter(paramName, propValue != null && (BigInteger)propValue != int.MinValue ? BigInteger.Parse(propValue.ToString()) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.BigInt;
                            break;
                        case "DateTime":
                            parameter = new SqlParameter(paramName, propValue != null && (DateTime)propValue != DateTime.MinValue ? Convert.ToDateTime(propValue) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.DateTime;
                            break;
                        case "Single":
                            parameter = new SqlParameter(paramName, propValue != null && (float)propValue != float.MinValue ? Convert.ToSingle(propValue) : DBNull.Value);
                            break;
                        case "DataTable":
                            parameter = new SqlParameter(paramName, propValue != null && (float)propValue != float.MinValue ? Convert.ToSingle(propValue) : DBNull.Value);
                            break;
                        case "Decimal":
                            parameter = new SqlParameter(paramName, propValue != null && (decimal)propValue != decimal.MinValue ? Convert.ToDecimal(propValue) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.Decimal;
                            break;
                        case "Double":
                            parameter = new SqlParameter(paramName, propValue != null && (double)propValue != double.MinValue ? Convert.ToDouble(propValue) : DBNull.Value);
                            parameter.SqlDbType = SqlDbType.Float;
                            break;
                        case "Boolean":
                            parameter = new SqlParameter(paramName, propValue != null ? Convert.ToBoolean(propValue) : DBNull.Value);
                            break;
                        default:
                            parameter = new SqlParameter(paramName, propValue ?? DBNull.Value);
                            break;
                    }
                    list.Add(parameter);
                }
            }

            return list;
        }

        public string returnStoredProcedureString(string spName)
        {
            string strSql = "Exec " + spName + " ";

            foreach (var prop in GetType().GetProperties())
            {
                if (((SqlParameterAttribute)((Attribute[])prop.GetCustomAttributes())[0]).IsParameter)
                {
                    strSql += $" @{prop.Name},";
                }
            }
            return strSql.Substring(0, strSql.Length - 1);
        }
    }
}
