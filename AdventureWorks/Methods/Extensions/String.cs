using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Methods.Extensions
{
    public static class String
    {
        public static string Left(this System.String str, int length)
        {
            try
            {
                return str.Substring(0, length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Mid(this System.String str, int startIndex, int length)
        {
            try
            {
                return str.Substring(startIndex, length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static int WordCount(this System.String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
