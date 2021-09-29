namespace Pz.Cheeseria.Api
{
    public class Urls
    {
        public const string Root = "/";

        private const string ApiRoot = "/api";

        public class V1
        {
            private const string Version = ApiRoot + "/v1";

            public class Dbo
            {
                private const string Prefix = Version + "/dbo";

                public class Cheese
                {
                    public const string GetCheesesbyId = Prefix + "/getCheese/{id}";
                    public const string SetCart = Prefix + "/cheese/{id}";
                }
            }
        }
    }
}
