using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configuration
{
    public static class Constants
    {
        public const string SUPERADMIN = "SuperAdmin";
        public const string ADMINISTRATOR = "Administrator";
        public const string REGISTEREDUSER = "RegisteredUser";
        public const string ADMIN_OR_SUPERADMIN = ADMINISTRATOR + "," + SUPERADMIN;
    }
}
