using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Enums;
namespace BussinessLayer.CommonUtility
{
   public class CommonHelper
    {

        public static T GetValueFromName<T>(string name) where T : Enum
        {
            var gender = (T)Enum.Parse(typeof(T), name);
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == gender.ToString())
                    {
                        return (T)field.GetValue(null);
                    }
                }

                if (field.Name == gender.ToString())
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}
