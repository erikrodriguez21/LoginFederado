using LoginGoogle.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace LoginGoogle.Helper
{
    public class Permisos : AuthorizeAttribute
    {
        private readonly int _permiso;
        ApplicationDbContext _dbCntx;
        private bool isInRol = false;

        public Permisos(int permiso)
        {            
            _permiso = permiso;
            _dbCntx = new ApplicationDbContext();
        }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {           
            if (!httpContext.Request.IsAuthenticated)
                return false;

            
            foreach (var item in base.Roles.Split(','))
            {
                if (httpContext.User.IsInRole(item))
                {
                    isInRol = true;
                }
            }

            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_dbCntx));
            //var user = UserManager.FindByEmail(httpContext.User.Identity.Name);

            if (isInRol)
            {
                if (System.Web.HttpContext.Current.Session["Permisos"] != null)
                {
                    foreach (var item in System.Web.HttpContext.Current.Session["Permisos"] as List<PermisosDto>)
                    {
                        if (item.IdPermiso == _permiso) return true;
                    }
                }
            }


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
        public static class Clientes // 100
        {
            public const int VerCreditoCliente = 100;             
        }

        public static class Ventas // 200
        {
            //Usuario
            public const int VerCredidos = 200;
            public const int VerClientes = 201;
            public const int VerCredidoActivo = 202;
            public const int VerCredidoEnAplicacion = 203;
            public const int VerHistorialDeCredido = 204; 
            public const int ModificarInformacionDeCreditos = 205;
            public const int Impersonar = 206;
            public const int CrearNuevaAplicacion = 207;
            //Manager todo lo anterior mas --->
            public const int AltaDeCreditos = 208;
            public const int PasarSiguientePaso = 209;
            public const int RegresarPasoAnterior = 210;
            public const int RechasarCreditos = 211; 
            public const int VerEditarPromocodes = 212;
            //Admin todo lo anterior mas --->
            public const int VerEditarValidaciones = 213;
            public const int VerEditarFeriados = 214; 
            public const int VerEditarReportesNipBc = 215;           
            //SuperAdmin todo lo anterior mas --->
            public const int VerEditarConfiguracion = 216;
        }

        public static class Cumplimiento // 300 
        {
            public const int VerOperaconesCumplimiento = 300;
            public const int VerPanelCNBV = 301;
        }

        public static class Facturacion // 400  
        {
            //usuario
            public const int VerFacturasEchas = 400;
            public const int VerPanelDeFacturacion = 401;
            //manager todo lo anterior mas --->
            public const int ForzarFacturacion = 402;
            public const int ForzarFinDeMes = 403;
            public const int ForzarTimbrado = 404;            
        }

        public static class Contabilidad // 500  
        { 
            //user
            public const int GenerarEditarBorrarCargosMoratorios = 500;
            //manager
            public const int VerMovimientos = 501;
            public const int CambiarHorariosDeConciliacion = 502; 
            public const int ForzarConciliacion = 503; 
            public const int GenerarCargosMoratorios = 504;
            public const int DescargarReportesPagosCobranza = 505;
            public const int MandarRecuperacionForzosa = 506;            
            //Admin
            public const int VerReporteGenral = 507;
            public const int VerificarConexionConXero = 508;
            public const int SicronizacionConXero = 509;  
            public const int ExportarAcsvMovimientos = 510;
        }
         
        public static class MKT // 600 
        {
            //user
            public const int VerAlertas = 600;
            public const int VerPanelDeAlertas = 602;
            //manager
            public const int CrearEliminarAlertas = 603;
        }

        public static class UserAdmin // 700  
        {
            public const int CrearUsuariosTipoClientes = 700;
            public const int CrearUsuariosTipoUsuarios = 701;
            public const int CrearUsuariosTipoManager = 702;
            public const int CrearUsuariosTipoAdmin = 703;
            public const int CrearUsuariosTipoSuperAdmin = 704;

        }
    }
}