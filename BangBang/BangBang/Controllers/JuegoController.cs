using BangBang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BangBang.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public JsonResult IniciarPartida()
        {
            Estado estado = new Estado();
            Datos datos = estado.InicioPartidaRegistro();
            //string a = new JavaScriptSerializer().Serialize(datos);
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InicioPartida(Datos datos)
        {
            //Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            bool ans = estado.InicioPartida(datos);
            //string a = new JavaScriptSerializer().Serialize(ans);
            return Json(ans, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Lanzar(DatosLanzamiento datos)
        {
            //DatosLanzamiento datos = new JavaScriptSerializer().Deserialize<DatosLanzamiento>(json);
            Estado estado = new Estado();
            bool resultado = estado.Lanzamiento(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Estado(Datos datos)
        {
            //Datos datos = new JavaScriptSerializer().Deserialize<Datos>(json);
            Estado estado = new Estado();
            bool resultado = estado.Turno(datos);
            //string a = new JavaScriptSerializer().Serialize(resultado);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}