using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCompletionsProcessor
{
    public static class AuthContext
    {
        public static string ClientId { get; set; }
        public static string Secret { get; set; }
        public static string TenantId { get; set; }
    }
}
