using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Tools
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static T Next<T>(this T src) where T : Enum
        {
            T[] array = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) + 1;
            return array.Length == j ? array[0] : array[j];
        }

        public static T NextOrLast<T>(this T src) where T : Enum
        {
            T[] array = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) + 1;
            return array.Length == j ? array[array.Length - 1] : array[j];
        }

        public static T Prev<T>(this T src) where T : Enum
        {
            T[] array = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) - 1;
            return j == -1 ? array[array.Length - 1] : array[j];
        }

        public static T PrevOrFirst<T>(this T src) where T : Enum
        {
            T[] array = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) - 1;
            return j == -1 ? array[0] : array[j];
        }

        public static IEnumerable<Enum> GetFlags(this Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
        }
    }
}
