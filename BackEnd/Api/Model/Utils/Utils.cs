using System.Data;
using System.Numerics;
using Microsoft.IdentityModel.Tokens;

public class Utils
{
    public static string DRToString(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? row[column].ToString() : string.Empty;
    }
    public static int DRToInt(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? int.Parse(row[column].ToString()) : int.MinValue;
    }
    public static long DRToBigInt(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? long.Parse(row[column].ToString()) : int.MinValue;
    }
    public static int DRToIntNoMinValue(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? int.Parse(row[column].ToString()) : 0;
    }
    public static long DRToBitIntNoMinValue(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? long.Parse(row[column].ToString()) : 0;
    }

    public static DateTime DRToDateTime(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? DateTime.Parse(row[column].ToString()) : DateTime.MinValue;
    }

    public static float DRToFloat(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? float.Parse(row[column].ToString()) : float.MinValue;
    }

    public static decimal DRToDecimal(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? decimal.Parse(row[column].ToString()) : decimal.MinValue;
    }
    public static float DRToFloatNoMinValue(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? float.Parse(row[column].ToString()) : 0;
    }
    public static bool DRToBool(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) && int.Parse(row[column].ToString()) == 1;
    }
    public static int DRBitToInt(DataRow row, string column)
    {
        if (row.Table.Columns.Contains(column))
        {
            switch (row[column].ToString())
            {
                case "False":
                    return 0;
                case "True":
                    return 1;
                default:
                    return int.MinValue;
            }
        }
        return int.MinValue;
    }
    public static bool DRBitToBool(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && row[column].ToString().Equals("True");
    }

    public static bool DRIntToBool(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && row[column].ToString().Equals("1");
    }
    public static Double DRToDouble(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? Double.Parse(row[column].ToString()) : Double.MinValue;
    }
    public static Double DRToDoubleNoMinValue(DataRow row, string column)
    {
        return row.Table.Columns.Contains(column) && !string.IsNullOrEmpty(row[column].ToString()) ? Double.Parse(row[column].ToString()) : 0;
    }
    public static double? DRToNullableDouble(DataRow row, string column)
    {
        return (!row.Table.Columns.Contains(column) || row[column] == DBNull.Value) ? null : double.Parse(row[column].ToString());
    }

    public static string TreatString(string str)
    {
        return !str.IsNullOrEmpty() ? str : string.Empty;
    }

    public static int TreatInt(int integer)
    {
        return integer != 0 ? integer : int.MinValue;
    }
    public static int TreatIntNoMinValue(int number)
    {
        return number > 0 ? number : 0;
    }

    public static long Treatlong(long number)
    {
        return number != 0 ? number : long.MinValue;
    }
    public static long TreatlongNoMinValue(long number)
    {
        return number > 0 ? number : 0;
    }
    public static BigInteger TreatBigInteger(BigInteger number)
    {
        return number != 0 ? number : int.MinValue;
    }
    public static BigInteger TreatBigIntegerNoMinValue(BigInteger number)
    {
        return number > 0 ? number : 0;
    }

    public static int TreatStatus(int number)
    {
        return !number.Equals(2) ? number : int.MinValue;
    }

    public static float TreatFloat(float flt)
    {
        return flt != 0.0 ? flt : float.MinValue;
    }

    public static decimal TreatDecimal(decimal number)
    {
        return decimal.Compare(number, decimal.Zero) == 1 ? number : decimal.MinValue;
    }

    public static int TreatBoolToInt(bool bol)
    {
        try
        {
            int result = bol == true ? 1 : 0;
            return result;
        }
        catch (Exception e)
        {
            return int.MinValue;
        }
    }

    public static DateTime TreatDateTime(DateTime dt)
    {
        string str = dt.ToString();
        return !str.IsNullOrEmpty() ? DateTime.Parse(str) : DateTime.MinValue;
    }

    public static double TreatDouble(double num)
    {
        return num != 0 ? num : double.MinValue;
    }
    public static int StringToInt(string str)
    {
        return str.IsNullOrEmpty() ? int.Parse(str) : int.MinValue;
    }

    public static string IntToString(int integer)
    {
        return integer != int.MinValue && !"".Equals(integer.ToString()) ? integer.ToString() : string.Empty;
    }

    public static float StringToFloat(string str)
    {
        return str.IsNullOrEmpty() ? float.Parse(str) : float.MinValue;
    }
    public static float StringToFloatNoMinValue(string str)
    {
        return str.IsNullOrEmpty() ? float.Parse(str) : 0;
    }
    public static int StringToIntNoMinValue(string str)
    {
        return str.IsNullOrEmpty() ? int.Parse(str) : 0;
    }
    public static int BooleanToInt(Boolean boolValue)
    {
        return boolValue ? 1 : 0;
    }

    public static Boolean IntToBoolean(int intValue)
    {
        return intValue == 1;
    }

    public static double StringToDouble(string str)
    {
        return str.IsNullOrEmpty() ? double.Parse(str) : double.MinValue;
    }

    public static string FirstCharToLowerCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        string firstChar = str.Substring(0, 1).ToLower();
        string rest = str[1..];

        return $"{firstChar}{rest}";
    }

    public static string FirstCharToUpperCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        string firstChar = str.Substring(0, 1).ToUpper();
        string rest = str[1..];

        return $"{firstChar}{rest}";
    }

    public static Boolean IsNull(object? obj)
    {
        return obj == null;
    }

}
