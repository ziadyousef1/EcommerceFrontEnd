using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public static class Constants
    {
        public static class Product
        {
            public const string GetAll = "api/Product";
            public const string Get = "api/Product";
            public const string Create = "api/Product";
            public const string Update = "api/Product";
            public const string Delete = "api/Product";

        }
        public static class Category
        {
            public const string GetAll = "api/Category";
            public const string Get = "api/Category";
            public const string Create = "api/Category";
            public const string Update = "api/Category";
            public const string Delete = "api/Category";
            public const string GetProductsByCategory = "api/Product/productsByCategory";
        }
        public static class ApiCallType
        {
            public const string Get = "GET";
            public const string Post = "POST";
            public const string Put = "PUT";
            public const string Delete = "DELETE";
        }
        public static class Authentication
        {
            public const string Type = "Bearer";
            public const string Login = "api/Authentication/login";
            public const string Register = "api/Authentication/register";
            public const string RefreshToken = "api/Authentication/refreshToken";
        }
        public static class Cookie
        {
            public const string Name = "token";
            public const string Path ="/";
            public const int Days = 1;

        }
        public static class ApiClient
        {
            public const string Name = "Blazor-Client";
        }
        public static class Payment
        {
            public const string GetAll = "api/Payment-Methods";
        }
        public static class Cart
        {
            public const string Checkout = "api/Payment/checkout";
            public const string SaveCart = "api/Payment/saveCheckOutHistory";
            public const string Name = "my-cart";
        }

    }
}
