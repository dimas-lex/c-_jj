using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeveloperTest.Src
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class RegexUtilities
    {
        bool invalid = false;

        public bool IsValidEmail(string email)
        {
            invalid = false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email); 
                return addr.Address == email;
            }
            catch
            {
                return false;
            } 
        }
    }
}
