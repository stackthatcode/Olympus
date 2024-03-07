using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympus.Blocks.Security
{
    public static class EncodingExtensions
    {
        public static string ToBase64(this string message)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
        }

        public static string FromBase64(this string base64message)
        {
            var buffer = Convert.FromBase64String(base64message);
            return System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }
}
