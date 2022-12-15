namespace TestLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public class Class1
    {
        public static string GetUserAgent() => HttpContext.Current.Request.UserAgent;
        public static string GetUserAgentFromContext(HttpContextBase context) => HttpContext.Current.Request.UserAgent;

        public static void SetValue(string message) => HttpContext.Current.Session["message"] = new SessionValue { Message = message };
        public static string GetValue() => HttpContext.Current.Session["message"] is SessionValue i ? i.Message : "session value is null";
        public static void RegistrionSessionKeys(IDictionary<string, Type> mapping) => mapping.Add("message", typeof(SessionValue));

        public class SessionValue
        {
            public string Message { get; set; }
        }

    }
}
