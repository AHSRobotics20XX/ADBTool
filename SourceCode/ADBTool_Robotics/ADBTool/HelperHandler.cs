using ADBHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTool_Robotics
{
    internal class HelperHandler
    {
        public String StringBeforeDelimiter(String Value, String Delimiter)
        {
            String ReturnValue = Value;

            int DelimiterPos = Value.IndexOf(Delimiter);

            if (DelimiterPos >= 0)
            {
                ReturnValue = Value.Substring(0, DelimiterPos);
            }

            return ReturnValue;
        }
        public String StringAfterDelimiter(String Value, String Delimiter)
        {
            String ReturnValue = Value;
            int delimiterPos = Value.IndexOf(Delimiter);

            if (delimiterPos >= 0)
            {
                ReturnValue = Value.Substring(delimiterPos + Delimiter.Length).Trim();
            }

            return ReturnValue;
        }

        public bool IsStringNullOrEmpty(String line)
        {
            return String.IsNullOrEmpty(line);
        }
    }
}
