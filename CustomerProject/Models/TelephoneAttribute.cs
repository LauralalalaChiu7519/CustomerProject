using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerProject.Models
{
    public class TelephoneAttribute : DataTypeAttribute
    {
        public TelephoneAttribute() : base(DataType.Text)
        {
            ErrorMessage = "電話格式錯誤e.g. 0911-111111";
        }


        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
             return System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), @"\d{4}-\d{6}");
        }
    }
}