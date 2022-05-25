using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class DoubleFormatter
{
    public static double ConvertStringToDouble(string value)
    {
        return Convert.ToDouble(value.Replace('.', ','));
    }

    public static string ConvertDoubleToString(double value)
    {
        return value.ToString("N2", CultureInfo.InvariantCulture);
    }

    public static bool TryParse(string value, out double converted)
    {
        double newValue;
        bool convert = double.TryParse(value.Replace('.', ','), out newValue);

        converted = newValue;
        return convert;
    }
}
