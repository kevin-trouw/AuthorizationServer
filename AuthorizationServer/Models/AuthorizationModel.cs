﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizationServer.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public int EnvironmentID { get; set; }
        public string EnvironmentName { get; set; }
    }

    public class EnvironmentModel
    {
        public int EnvironmentID { get; set; }
        public string EnvironmentName { get; set; }
        public int AppID { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
    }

    public class AppModel
    {
        public int AppID { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public int EnvironmentID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int PermissionGroupID { get; set; }
        public string PermissionGroupName { get; set; }
    }

    public class RoleModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int AppID { get; set; }
        public string AppName { get; set; }
    }

    public class PermissionGroupModel
    {
        public int PermissionGroupID { get; set; }
        public string PermissionGroupName { get; set; }
        public int AppID { get; set; }
        public string AppName { get; set; }
    }

    public class PermissionGroup_RoleModel
    {
        public int PermissionGroupID { get; set; }
        public string PermissionGroupName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class PermissionModel
    {
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public int RoleID { get; set; }
        public string Description { get; set; }
    }
}