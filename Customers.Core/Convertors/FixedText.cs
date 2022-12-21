using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Core.Convertors
{
   public class FixedText
    {
        public static string FixedEmail(string email)
        {
            return email.Trim().ToLower();
        }

        public static string FixedString(string text)
        {
            return text.Trim();
        }
    }
}
