using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MyJetWallet.Unlimint
{
    public static partial class Extensions
    {
        internal static string ConvertValueToString(this object value)
        {
            switch (value)
            {
                case bool boolValue:
                    return boolValue ? "true" : "false";

                case string stringValue:
                    return stringValue;

                default:
                    return value?.ToString();
            }
        }

        internal static string SecureStringToString(this SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        internal static SecureString StringToSecureString(this string str)
        {
            var secureStr = new SecureString();
            if (str.Length > 0)
            {
                foreach (var c in str.ToCharArray()) secureStr.AppendChar(c);
            }

            return secureStr;
        }
    }
}