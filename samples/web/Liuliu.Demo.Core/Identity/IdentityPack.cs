﻿// -----------------------------------------------------------------------
//  <copyright file="IdentityPack.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2020 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2020-02-15 17:31</last-date>
// -----------------------------------------------------------------------

using System.ComponentModel;

using Liuliu.Demo.Identity.Entities;

using Microsoft.Extensions.DependencyInjection;

using OSharp.Identity;


namespace Liuliu.Demo.Identity
{
    /// <summary>
    /// 身份认证模块，此模块必须在MVC模块之前启动
    /// </summary>
    [Description("身份认证模块")]
    public class IdentityPack : IdentityPackBase<UserStore, RoleStore, User, Role, int, int>
    {
        /// <summary>
        /// 将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityContract, IdentityService>();

            return base.AddServices(services);
        }
    }
}