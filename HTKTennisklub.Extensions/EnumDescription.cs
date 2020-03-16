using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.Extensions
{
    public static class EnumDescription
    {
        public static string GetDescription<Enum>(this Enum enumerationValue) 
        {
            MemberInfo[] memberInfo = enumerationValue.GetType().GetMember(enumerationValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0) 
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Length > 0)
                        return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumerationValue.ToString();
        }
    }
}
