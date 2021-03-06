﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liuliu.Demo.Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identity_Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_Organization_Identity_Organization_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Identity_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Security_EntityInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TypeName = table.Column<string>(nullable: false),
                    AuditEnabled = table.Column<bool>(nullable: false),
                    PropertyJson = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_EntityInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_Function",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    IsController = table.Column<bool>(nullable: false),
                    IsAjax = table.Column<bool>(nullable: false),
                    AccessType = table.Column<int>(nullable: false),
                    IsAccessTypeChanged = table.Column<bool>(nullable: false),
                    AuditOperationEnabled = table.Column<bool>(nullable: false),
                    AuditEntityEnabled = table.Column<bool>(nullable: false),
                    CacheExpirationSeconds = table.Column<int>(nullable: false),
                    IsCacheSliding = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    OrderCode = table.Column<double>(nullable: false),
                    TreePathString = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_Module_Security_Module_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Security_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Systems_AuditOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FunctionName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    OperationSystem = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    ResultType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Elapsed = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems_AuditOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems_KeyValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValueJson = table.Column<string>(nullable: true),
                    ValueType = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems_KeyValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_ModuleFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    FunctionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_ModuleFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_ModuleFunction_Security_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Security_Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_ModuleFunction_Security_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Security_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Systems_AuditEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    EntityKey = table.Column<string>(nullable: true),
                    OperateType = table.Column<int>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems_AuditEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_AuditEntity_Systems_AuditOperation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Systems_AuditOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Systems_AuditProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    OriginalValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    AuditEntityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems_AuditProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_AuditProperty_Systems_AuditEntity_AuditEntityId",
                        column: x => x.AuditEntityId,
                        principalTable: "Systems_AuditEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_EntityRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    Operation = table.Column<int>(nullable: false),
                    FilterGroupJson = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_EntityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_EntityRole_Security_EntityInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Security_EntityInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security_ModuleRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_ModuleRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_ModuleRole_Security_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Security_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity_LoginLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    LogoutTime = table.Column<DateTime>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_LoginLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: false),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegisterIp = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_UserToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infos_Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    MessageType = table.Column<int>(nullable: false),
                    NewReplyCount = table.Column<int>(nullable: false),
                    IsSended = table.Column<bool>(nullable: false),
                    CanReply = table.Column<bool>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    MessageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_Role_Infos_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Identity_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizeEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    HeadImg = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    MessageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_User_Infos_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Infos_MessageReceive",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: false),
                    NewReplyCount = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    MessageId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos_MessageReceive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReceive_Infos_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReceive_Identity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Infos_MessageReply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    ParentMessageId = table.Column<Guid>(nullable: false),
                    ParentReplyId = table.Column<Guid>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BelongMessageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos_MessageReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReply_Infos_Message_BelongMessageId",
                        column: x => x.BelongMessageId,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReply_Infos_Message_ParentMessageId",
                        column: x => x.ParentMessageId,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReply_Infos_MessageReply_ParentReplyId",
                        column: x => x.ParentReplyId,
                        principalTable: "Infos_MessageReply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Infos_MessageReply_Identity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Security_EntityUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    FilterGroupJson = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_EntityUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_EntityUser_Security_EntityInfo_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Security_EntityInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_EntityUser_Identity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security_ModuleUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_ModuleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_ModuleUser_Security_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Security_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_ModuleUser_Identity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Identity_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedTime", "DeletedTime", "IsAdmin", "IsDefault", "IsLocked", "IsSystem", "MessageId", "Name", "NormalizedName", "Remark" },
                values: new object[] { 1, "97313840-7874-47e5-81f2-565613c8cdcc", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, false, true, null, "系统管理员", "系统管理员", "系统最高权限管理角色" });

            migrationBuilder.InsertData(
                table: "Security_Module",
                columns: new[] { "Id", "Code", "Name", "OrderCode", "ParentId", "Remark", "TreePathString" },
                values: new object[] { 1, "Root", "根节点", 1.0, null, "系统根节点", "$1$" });

            migrationBuilder.InsertData(
                table: "Systems_KeyValue",
                columns: new[] { "Id", "IsLocked", "Key", "ValueJson", "ValueType" },
                values: new object[,]
                {
                    { new Guid("534d7813-0eea-44cc-b88e-a9cb010c6981"), false, "Site.Name", "\"OSHARP\"", "System.String,System.Private.CoreLib" },
                    { new Guid("977e4bba-97b2-4759-a768-a9cb010c698c"), false, "Site.Description", "\"Osharp with .NetStandard2.0 & Angular6\"", "System.String,System.Private.CoreLib" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identity_LoginLog_UserId",
                table: "Identity_LoginLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_Organization_ParentId",
                table: "Identity_Organization",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_Role_MessageId",
                table: "Identity_Role",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Identity_Role",
                columns: new[] { "NormalizedName", "DeletedTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_RoleClaim_RoleId",
                table: "Identity_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_User_MessageId",
                table: "Identity_User",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Identity_User",
                columns: new[] { "NormalizeEmail", "DeletedTime" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Identity_User",
                columns: new[] { "NormalizedUserName", "DeletedTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserClaim_UserId",
                table: "Identity_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserDetail_UserId",
                table: "Identity_UserDetail",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserLogin_UserId",
                table: "Identity_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserLoginIndex",
                table: "Identity_UserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserRole_RoleId",
                table: "Identity_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserRoleIndex",
                table: "Identity_UserRole",
                columns: new[] { "UserId", "RoleId", "DeletedTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserTokenIndex",
                table: "Identity_UserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infos_Message_SenderId",
                table: "Infos_Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReceive_MessageId",
                table: "Infos_MessageReceive",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReceive_UserId",
                table: "Infos_MessageReceive",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReply_BelongMessageId",
                table: "Infos_MessageReply",
                column: "BelongMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReply_ParentMessageId",
                table: "Infos_MessageReply",
                column: "ParentMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReply_ParentReplyId",
                table: "Infos_MessageReply",
                column: "ParentReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_MessageReply_UserId",
                table: "Infos_MessageReply",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ClassFullNameIndex",
                table: "Security_EntityInfo",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_EntityRole_RoleId",
                table: "Security_EntityRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EntityRoleIndex",
                table: "Security_EntityRole",
                columns: new[] { "EntityId", "RoleId", "Operation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_EntityUser_UserId",
                table: "Security_EntityUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EntityUserIndex",
                table: "Security_EntityUser",
                columns: new[] { "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "AreaControllerActionIndex",
                table: "Security_Function",
                columns: new[] { "Area", "Controller", "Action" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_Module_ParentId",
                table: "Security_Module",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Security_ModuleFunction_FunctionId",
                table: "Security_ModuleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "ModuleFunctionIndex",
                table: "Security_ModuleFunction",
                columns: new[] { "ModuleId", "FunctionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_ModuleRole_RoleId",
                table: "Security_ModuleRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "ModuleRoleIndex",
                table: "Security_ModuleRole",
                columns: new[] { "ModuleId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_ModuleUser_UserId",
                table: "Security_ModuleUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ModuleUserIndex",
                table: "Security_ModuleUser",
                columns: new[] { "ModuleId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Systems_AuditEntity_OperationId",
                table: "Systems_AuditEntity",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_AuditProperty_AuditEntityId",
                table: "Systems_AuditProperty",
                column: "AuditEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_RoleClaim_Identity_Role_RoleId",
                table: "Identity_RoleClaim",
                column: "RoleId",
                principalTable: "Identity_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserRole_Identity_User_UserId",
                table: "Identity_UserRole",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserRole_Identity_Role_RoleId",
                table: "Identity_UserRole",
                column: "RoleId",
                principalTable: "Identity_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_EntityRole_Identity_Role_RoleId",
                table: "Security_EntityRole",
                column: "RoleId",
                principalTable: "Identity_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_ModuleRole_Identity_Role_RoleId",
                table: "Security_ModuleRole",
                column: "RoleId",
                principalTable: "Identity_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_LoginLog_Identity_User_UserId",
                table: "Identity_LoginLog",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserClaim_Identity_User_UserId",
                table: "Identity_UserClaim",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserDetail_Identity_User_UserId",
                table: "Identity_UserDetail",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserLogin_Identity_User_UserId",
                table: "Identity_UserLogin",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UserToken_Identity_User_UserId",
                table: "Identity_UserToken",
                column: "UserId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_Message_Identity_User_SenderId",
                table: "Infos_Message",
                column: "SenderId",
                principalTable: "Identity_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infos_Message_Identity_User_SenderId",
                table: "Infos_Message");

            migrationBuilder.DropTable(
                name: "Identity_LoginLog");

            migrationBuilder.DropTable(
                name: "Identity_Organization");

            migrationBuilder.DropTable(
                name: "Identity_RoleClaim");

            migrationBuilder.DropTable(
                name: "Identity_UserClaim");

            migrationBuilder.DropTable(
                name: "Identity_UserDetail");

            migrationBuilder.DropTable(
                name: "Identity_UserLogin");

            migrationBuilder.DropTable(
                name: "Identity_UserRole");

            migrationBuilder.DropTable(
                name: "Identity_UserToken");

            migrationBuilder.DropTable(
                name: "Infos_MessageReceive");

            migrationBuilder.DropTable(
                name: "Infos_MessageReply");

            migrationBuilder.DropTable(
                name: "Security_EntityRole");

            migrationBuilder.DropTable(
                name: "Security_EntityUser");

            migrationBuilder.DropTable(
                name: "Security_ModuleFunction");

            migrationBuilder.DropTable(
                name: "Security_ModuleRole");

            migrationBuilder.DropTable(
                name: "Security_ModuleUser");

            migrationBuilder.DropTable(
                name: "Systems_AuditProperty");

            migrationBuilder.DropTable(
                name: "Systems_KeyValue");

            migrationBuilder.DropTable(
                name: "Security_EntityInfo");

            migrationBuilder.DropTable(
                name: "Security_Function");

            migrationBuilder.DropTable(
                name: "Identity_Role");

            migrationBuilder.DropTable(
                name: "Security_Module");

            migrationBuilder.DropTable(
                name: "Systems_AuditEntity");

            migrationBuilder.DropTable(
                name: "Systems_AuditOperation");

            migrationBuilder.DropTable(
                name: "Identity_User");

            migrationBuilder.DropTable(
                name: "Infos_Message");
        }
    }
}
