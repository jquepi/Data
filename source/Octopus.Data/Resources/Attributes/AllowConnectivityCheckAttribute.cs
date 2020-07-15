using System;
using Octopus.Data.Model;

namespace Octopus.Data.Resources.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AllowConnectivityCheckAttribute : Attribute
    {
        public readonly Href ApiEndpoint;
        public readonly string ConnectivityCheckTitle;
        public readonly string[] DependsOnPropertyNames;

        public AllowConnectivityCheckAttribute(string connectivityCheckTitle,
            string apiEndpoint,
            params string[] dependsOnPropertyNames)
        {
            ConnectivityCheckTitle = connectivityCheckTitle;
            ApiEndpoint = apiEndpoint;
            DependsOnPropertyNames = dependsOnPropertyNames;
        }
    }
}