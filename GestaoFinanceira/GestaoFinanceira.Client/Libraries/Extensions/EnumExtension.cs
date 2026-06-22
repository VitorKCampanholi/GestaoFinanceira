using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GestaoFinanceira.Client.Libraries.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var memberInfo = enumType.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0)
            {
                var displayAtribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAtribute != null)
                {

                    if (displayAtribute.Name != null)
                        return displayAtribute.Name;
                }

            }
            return enumValue.ToString();
        }
    }
}

