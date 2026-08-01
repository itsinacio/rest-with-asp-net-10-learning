namespace RestWithASPNET.Utils;

public class NumberHelper
{
    public static bool isNumeric(string number)
    {
        decimal value;
        bool isNumber = decimal.TryParse(number,
        System.Globalization.NumberStyles.Any,
        System.Globalization.NumberFormatInfo.InvariantInfo,
        out value);
        return isNumber;
    }
    public static decimal ConvertToDecimal(string number)
    {
        decimal value;
        if (decimal.TryParse(number,
        System.Globalization.NumberStyles.Any,
        System.Globalization.NumberFormatInfo.InvariantInfo,
        out value))
        {
            return value;
        }
        return 0;
    }
}
