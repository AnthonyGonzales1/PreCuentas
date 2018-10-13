using PresupuestoCuentas.DAL;
using PresupuestoCuentas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.BLL
{
    public class PreCuentasDetalleBLL
    {
        public static bool Guardar(PreCuentasDetalle preCuentasDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Detalle.Add(preCuentasDetalle) != null)
                {
                    contexto.SaveChanges();
                    contexto.Dispose();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Detalle.Find(Id);
                if (eliminar != null)
                {
                    contexto.Entry(eliminar).State = EntityState.Deleted;
                    if (contexto.SaveChanges() > 0)
                    {
                        contexto.Dispose();
                        paso = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(PreCuentasDetalle preCuentasDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(preCuentasDetalle).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static PreCuentasDetalle Buscar(int id)
        {
            PreCuentasDetalle partido = new PreCuentasDetalle();
            Contexto contexto = new Contexto();
            try
            {
                partido = contexto.Detalle.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return partido;
        }

        public static List<PreCuentasDetalle> GetList(Expression<Func<PreCuentasDetalle, bool>> prec)
        {
            List<PreCuentasDetalle> preCuentasDetalles = new List<PreCuentasDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                preCuentasDetalles = contexto.Detalle.Where(prec).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return preCuentasDetalles;
        }
    }
}
