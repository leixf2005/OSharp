﻿// -----------------------------------------------------------------------
//  <copyright file="ApiResourceClaimConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2020 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2020-02-19 23:00</last-date>
// -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Entity;
using OSharp.IdentityServer4.Entities;


namespace OSharp.IdentityServer4.EntityFrameworkCore
{
    /// <summary>
    /// API资源声明信息映射配置类
    /// </summary>
    public class ApiResourceClaimConfiguration : Id4EntityTypeConfigurationBase<ApiResourceClaim, int>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
        { }
    }
}