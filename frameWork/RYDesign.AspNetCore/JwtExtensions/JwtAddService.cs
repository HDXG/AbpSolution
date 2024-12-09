using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RYDesign.AspNetCore.Utils;

namespace RYDesign.AspNetCore.JwtExtensions
{
    public static  class JwtAddService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void JwtConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                //取出配置的私钥
                var SecretKeyDemo = Encoding.UTF8.GetBytes(Md5CryptUtils.Md5Encrypt(configuration["AuthenticationDemo:SecretKeyDemo"] ?? "") );
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    //验证发布者
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AuthenticationDemo:IssuerDemo"],
                    //验证接收者
                    ValidateAudience = true,
                    ValidAudience = configuration["AuthenticationDemo:AudienceDemo"],
                    //验证是否过期
                    ValidateLifetime = true,
                    //验证私钥
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKeyDemo)
                };
            });
        }
    }
}
