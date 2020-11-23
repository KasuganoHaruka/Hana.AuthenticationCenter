using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AuthenticationCenter
{
    public class ApiInitConfig
    {
        /// <summary>
        /// 这个ApiResource参数就是我们的Api
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources =>
          new[]
           {
               new ApiResource("api1", "Demo API")
               {
                   Scopes ={ "api1.finduser.scope" ,"api1.findall.scope" }
               },
               //new ApiResource("api2", "Demo API")
               //{
               //    Scopes ={ "scope2" }
               //}
           };

        public static IEnumerable<ApiScope> GetApiScopes =>
            new List<ApiScope> {
                new ApiScope("api1.finduser.scope"),
                new ApiScope("api1.findall.scope"),
            };


        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new List<IdentityResource>
                {
                   new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                };

        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                    new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,   //客户端授权
                    ClientSecrets = { new Secret("secret".Sha256()) },  //客户端密码
                    //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //资源所有者密码授权
                    AllowedScopes = { "api1.finduser.scope", "offline_access" },    //客户端有权访问的范围（Scopes）
                    AllowOfflineAccess = true,
                        Claims = new List<ClientClaim>(){
                        new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                        new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"管理员"),
                        new ClientClaim("Sora","穹"),
                    }
                }



                    // // OpenID Connect
                    // new Client
                    //{
                    //    ClientId = "mvc",
                    //    ClientName = "MVC Client",
                    //    AllowedGrantTypes = GrantTypes.Implicit,

                    //    RedirectUris = { "http://localhost:5000/signin-oidc" },
                    //    PostLogoutRedirectUris = { "http://localhost:5000" },

                    //    AllowedScopes =
                    //    {
                    //        IdentityServerConstants.StandardScopes.OpenId,
                    //        IdentityServerConstants.StandardScopes.Profile
                    //    }
                    //}
            };

        public static List<TestUser> GetUsers =>
           new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="Asuna",
                    Password="password"
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "Hana",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "Hana"),
                        new Claim("website", "http://www.baidu.com")
                    }
                }
            };
    }


    //public static class Config
    //{
    //    public static IEnumerable<IdentityResource> IdentityResources =>
    //        new IdentityResource[]
    //        {
    //        new IdentityResources.OpenId(),
    //        new IdentityResources.Profile(),
    //        };

    //    public static IEnumerable<ApiScope> ApiScopes =>
    //        new ApiScope[]
    //        {
    //        new ApiScope("scope1"),
    //            //new ApiScope("scope2"),
    //        };

    //    public static IEnumerable<ApiResource> ApiResources =>
    //        new ApiResource[]
    //        {
    //        new ApiResource("api1","#api1")
    //        {
    //            //!!!重要
    //            Scopes = { "scope1"}
    //        },
    //            //new ApiResource("api2","#api2")
    //            //{
    //            //    //!!!重要
    //            //    Scopes = { "scope2"}
    //            //},
    //        };

    //    public static IEnumerable<Client> Clients =>
    //        new Client[]
    //        {
    //        new Client
    //        {
    //            ClientId = "postman client",
    //            ClientName = "Client Credentials Client",

    //            AllowedGrantTypes = GrantTypes.ClientCredentials,
    //            ClientSecrets = { new Secret("postman secret".Sha256()) },

    //            AllowedScopes = { "scope1" }
    //        },
    //        };
    //}
}
