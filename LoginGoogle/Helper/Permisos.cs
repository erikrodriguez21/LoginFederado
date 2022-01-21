using System.Web;
using System.Web.Mvc;

namespace LoginGoogle.Helper
{
    public class Permisos : AuthorizeAttribute
    {
        private readonly int _permiso;

        public Permisos(int permiso)
        {
            _permiso = permiso; 
        }


        //logica para authorizar
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (!httpContext.Request.IsAuthenticated)
            //    return false;


            //var roles = System.Web.Security.Roles.GetRolesForUser(httpContext.User.Identity.Name);
            var listPermisos = HttpContext.Current.Session["Permisos"];
            /// logica

            return false;
        }




        #region Enums
        public enum Permiso
        {
            View,
            Add,
            Edit,
            Delete
        }
        public enum Role
        {
            Cliente,
            Usuario, 
            Manager,
            Admin,
            SuperAdmin
        }
        #endregion

         
    }

    public static class PermisosModulo
    {
        public static class Ventas // 100
        {
            public const int VerCredidos = 100;
            public const int VerClientes = 101;
        }

        public static class Cumplimiento // 200
        {
            public const int VerCredidos = 200;
            public const int VerClientes = 201;
        }



    }
}