using AuthorizationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace AuthorizationServer.Controllers
{
    public class AuthorizationController : Controller
    {
        // ---------- CUSTOMER ----------

        // GET: Customers
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<CustomerModel>("CustomerViewAll", null));
        }

        // GET: Environments of Customer
        public ActionResult CustomerViewEnvironment(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", id);

            return View(DapperORM.ReturnList<CustomerModel>("CustomerViewDetails", param));
        }

        // DELETE: Customer
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", id);
            DapperORM.ExecuteWithoutReturn("CustomerDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- ENVIRONMENT ----------

        

        // EDIT: Environment
        [HttpGet]
        public ActionResult EnvironmentAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EnvironmentID", id);
                
                return View(DapperORM.ReturnList<EnvironmentModel>("EnvironmentViewAllByID", param).FirstOrDefault<EnvironmentModel>());
            }
        }

        // ADD: Environment
        [HttpPost]
        public ActionResult EnvironmentAddOrEdit(EnvironmentModel environmentModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EnvironmentID", environmentModel.EnvironmentID);
            param.Add("@EnvironmentName", environmentModel.EnvironmentName);
            param.Add("@CustomerID", environmentModel.CustomerID);
            

            DapperORM.ExecuteWithoutReturn("EnvironmentAddOrEdit", param);

            // ClientID (KlantID)
            int CustomerID = environmentModel.CustomerID;

            return Redirect("/Authorization/CustomerViewEnvironment/" + CustomerID);
        }

        // DELETE: Environment
        [HttpGet]
        public ActionResult DeleteEnvironment(EnvironmentModel environmentModel, int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EnvironmentID", id);
            DapperORM.ExecuteWithoutReturn("EnvironmentDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- APP ----------

        // GET: Apps of Environment
        public ActionResult EnvironmentViewApp(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EnvironmentID", id);

            return View(DapperORM.ReturnList<EnvironmentModel>("EnvironmentViewDetails", param));
        }

        // EDIT: App
        [HttpGet]
        public ActionResult AppAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AppID", id);

                return View(DapperORM.ReturnList<AppModel>("AppViewAllByID", param).FirstOrDefault<AppModel>());
            }
        }

        // ADD: App
        [HttpPost]
        public ActionResult AppAddOrEdit(AppModel appModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@AppID", appModel.AppID);
            param.Add("@AppName", appModel.AppName);
            param.Add("@Description", appModel.Description);
            param.Add("EnvironmentID", appModel.EnvironmentID);

            DapperORM.ExecuteWithoutReturn("AppAddOrEdit", param);

            // ClientID (KlantID)
            int EnvironmentID = appModel.EnvironmentID;
            return Redirect("/Authorization/EnvironmentViewApp/" + EnvironmentID);
        }

        // DELETE: App
        [HttpGet]
        public ActionResult DeleteApp(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@AppID", id);
            DapperORM.ExecuteWithoutReturn("AppDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- ROLES ----------
        
        // GET: Roles of App
        public ActionResult AppViewRole(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@AppID", id);

            return View(DapperORM.ReturnList<AppModel>("AppViewRoles", param));
        }

        // EDIT: Role
        [HttpGet]
        public ActionResult RoleAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@RoleID", id);

                return View(DapperORM.ReturnList<RoleModel>("RoleViewAllByID", param).FirstOrDefault<RoleModel>());
            }
        }

        // ADD: Role
        [HttpPost]
        public ActionResult RoleAddOrEdit(RoleModel roleModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleID", roleModel.RoleID);
            param.Add("@RoleName", roleModel.RoleName);
            param.Add("@AppID", roleModel.AppID);
            
            DapperORM.ExecuteWithoutReturn("RoleAddOrEdit", param);

            int AppID = roleModel.AppID;
            return Redirect("/Authorization/AppViewRole/" + AppID);
        }

        // DELETE: Role
        [HttpGet]
        public ActionResult DeleteRole(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleID", id);
            DapperORM.ExecuteWithoutReturn("RoleDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- PERMISSIONGROUPS ----------

        // GET: PermissionGroups of App
        public ActionResult AppViewPermissionGroup(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@AppID", id);

            return View(DapperORM.ReturnList<AppModel>("AppViewPermissionGroups", param));
        }

        // EDIT: PermissionGroup
        [HttpGet]
        public ActionResult PermissionGroupAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PermissionGroupID", id);

                return View(DapperORM.ReturnList<PermissionGroupModel>("PermissionGroupViewAllByID", param).FirstOrDefault<PermissionGroupModel>());
            }
        }

        // ADD: PermissionGroup
        [HttpPost]
        public ActionResult PermissionGroupAddOrEdit(PermissionGroupModel permissionGroupModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionGroupID", permissionGroupModel.PermissionGroupID);
            param.Add("@PermissionGroupName", permissionGroupModel.PermissionGroupName);

            DapperORM.ExecuteWithoutReturn("PermissionGroupAddOrEdit", param);

            // ClientID (KlantID)

            int AppID = permissionGroupModel.AppID;
            return Redirect("/Authorization/AppViewPermissionGroup/" + AppID);
        }

        // DELETE: PermissionGroup
        [HttpGet]
        public ActionResult DeletePermissionGroup(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionGroupID", id);
            DapperORM.ExecuteWithoutReturn("PermissionGroupDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- GET: PermissionGroup_Role of PermissionGroup ----------
        public ActionResult ViewPermissionGroupRole(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionGroupID", id);

            return View(DapperORM.ReturnList<PermissionGroup_RoleModel>("PROC_PermissionGroup_Role", param));
        }

        // ---------- Users ----------
        public ActionResult ViewUsersByRole(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleID", id);

            return View(DapperORM.ReturnList<UserModel>("UsersByRole", param));
        }

        public ActionResult ViewUserDetails(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", id);

            return View(DapperORM.ReturnList<UserModel>("UserViewAllByID", param));
        }

        [HttpGet]
        public ActionResult ViewUser(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", id);

                return View(DapperORM.ReturnList<UserModel>("UserViewAllByID", param).FirstOrDefault<UserModel>());
            }
        }

        // EDIT: User
        [HttpGet]
        public ActionResult UserAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", id);

                return View(DapperORM.ReturnList<UserModel>("UserViewAllByID", param).FirstOrDefault<UserModel>());
            }
        }

        // ADD: User
        [HttpPost]
        public ActionResult UserAddOrEdit(UserModel userModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userModel.UserID);
            param.Add("@UserName", userModel.UserName);
            param.Add("@RoleID", userModel.RoleID);


            DapperORM.ExecuteWithoutReturn("UserAddOrEdit", param);

            // ClientID (KlantID)
            int RoleID = userModel.RoleID;

            return Redirect("/Authorization/ViewUsersByRole/" + RoleID);
        }

        // DELETE USER
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", id);
            DapperORM.ExecuteWithoutReturn("UserDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }

        // ---------- PERMISSIONS ----------
        public ActionResult ViewPermissionsByRole(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleID", id);

            return View(DapperORM.ReturnList<PermissionModel>("PermissionsByRole", param));
        }


        // EDIT: Permission
        [HttpGet]
        public ActionResult PermissionAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PermissionID", id);

                return View(DapperORM.ReturnList<PermissionModel>("PermissionViewAllByID", param).FirstOrDefault<PermissionModel>());
            }
        }

        // ADD: Permission
        [HttpPost]

        public ActionResult PermissionAddOrEdit(PermissionModel permissionModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionID", permissionModel.PermissionID);
            param.Add("@PermissionName", permissionModel.PermissionName);
            
            DapperORM.ExecuteWithoutReturn("PermissionAddOrEdit", param);

            int RoleID = permissionModel.RoleID;
            return Redirect("/Authorization/ViewPermissionsByRole/" + RoleID);
        }

        // Get details
        [HttpGet]
        public ActionResult ViewPermissionDetails(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PermissionID", id);

                return View(DapperORM.ReturnList<PermissionModel>("PermissionViewAllByID", param).FirstOrDefault<PermissionModel>());
            }
        }

        [HttpGet]
        public ActionResult DeletePermission(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionID", id);
            DapperORM.ExecuteWithoutReturn("PermissionDeleteByID", param);

            return Redirect(Request.UrlReferrer.ToString());
        }


    }
}

