using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopNongSan
{
    public static class MyString
    {
        //ma hoa mat khau
        public static String ToMD5(this String s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var hash = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public static String Str_slug(this String s)
        {
            String[][] symbols =
            {
                new string[]{ "[áàạảãâấầậẩẫăắằặẳẵ]","a"},
                new string[]{ "[đ]","d"},
                new string[]{ "[éèẹẻẽêếềệểễ]", "e"},
                new string[]{ "[íìịỉĩ]", "i"},
                new string[]{ "[óòọỏõôốồộổỗơớờợởỡ]", "o"},
                new string[]{ "[úùụủũưứừựửữ]", "u"},
                new string[]{ "[ýỳỵỷỹ]", "y"},
                new string[]{ "[\\s'\";,]", "-"},

            };
            s = s.ToLower();
            foreach(var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
            return s;
        }    
    }
}