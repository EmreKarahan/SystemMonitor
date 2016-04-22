using System;
using System.Configuration;
using System.Data;


namespace OpenShift.Helper
{
    public class Connection
    {
     
        private static string ConnectionString
        {
            get
            {
#if DEBUG
                return ConfigurationManager.ConnectionStrings["aspConn"].ConnectionString;

#else
                var mySqlHost = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_HOST"))
                    ? ConfigurationManager.AppSettings["host"]
                    : Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_HOST");

                var mySqlUser =
                    string.IsNullOrEmpty(Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_USERNAME"))
                        ? "admin5QuNfpI"
                        : Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_USERNAME");

                var mySqlPass = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_PASSWORD"))
                    ? "aMbLJ6wpjGbT"
                    : Environment.GetEnvironmentVariable("OPENSHIFT_MYSQL_DB_PASSWORD");

                return string.Format("server={0};User Id={1};password={2};database=asp", mySqlHost, mySqlUser, mySqlPass);
#endif
            }
        }

    }
}
