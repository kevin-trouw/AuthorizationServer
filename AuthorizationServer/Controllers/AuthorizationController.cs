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



        // EDIT: Customer
        [HttpGet]
        public ActionResult CustomerAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", id);

                return View(DapperORM.ReturnList<CustomerModel>("CustomerViewAllByID", param).FirstOrDefault<CustomerModel>());
            }
        }

        // ADD: Customer
        [HttpPost]
        public ActionResult CustomerAddOrEdit(CustomerModel customerModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", customerModel.CustomerID);
            param.Add("@CustomerName", customerModel.CustomerName);
            param.Add("@Address", customerModel.Address);
            param.Add("@ContactPerson", customerModel.ContactPerson);
            DapperORM.ExecuteWithoutReturn("CustomerAddOrEdit", param);

            return RedirectToAction("Index");
        }

        // DELETE: Customer
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", id);
            DapperORM.ExecuteWithoutReturn("CustomerDeleteByID", param);

            return (RedirectToAction("Index"));
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

            DapperORM.ExecuteWithoutReturn("EnvironmentAddOrEdit", param);

            // ClientID (KlantID)

            return Redirect("/Authorization/CustomerViewEnvironment/4");
        }

        // DELETE: Environment
        [HttpGet]
        public ActionResult DeleteEnvironment(int id)
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
            

            DapperORM.ExecuteWithoutReturn("AppAddOrEdit", param);

            // ClientID (KlantID)

            return Redirect("/Authorization/CustomerViewEnvironment/7");
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

            DapperORM.ExecuteWithoutReturn("RoleAddOrEdit", param);

            // ClientID (KlantID)

            return Redirect("/Authorization/CustomerViewEnvironment/");
        }

        // DELETE: App
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

        // EDIT: Role
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

        // ADD: Role
        [HttpPost]
        public ActionResult PermissionGroupAddOrEdit(PermissionGroupModel permissionGroupModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PermissionGroupID", permissionGroupModel.PermissionGroupID);
            param.Add("@PermissionGroupName", permissionGroupModel.PermissionGroupName);

            DapperORM.ExecuteWithoutReturn("PermissionGroupAddOrEdit", param);

            // ClientID (KlantID)

            return Redirect("/Authorization/CustomerViewEnvironment/1");
        }

        // DELETE: App
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

        // ---------- PERMISSIONS ----------
        public ActionResult ViewPermissionsByRole(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleID", id);

            return View(DapperORM.ReturnList<PermissionModel>("PermissionsByRole", param));
        }

    }
}

