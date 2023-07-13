using MD.PersianDateTime.Standard;

namespace WareHousingApi.Common
{
    public static class ConvertDate
    {
        public static DateTime ConvertShamsiToMiladi(this string date)
        {
            PersianDateTime pdate = PersianDateTime.Parse(date);
            return pdate.ToDateTime();
        }

        public static string ConvertMiladiToShamsi(this DateTime date, string format)
        {
            PersianDateTime pdate = new PersianDateTime(date);
            return pdate.ToString(format);
        }
    }
}
