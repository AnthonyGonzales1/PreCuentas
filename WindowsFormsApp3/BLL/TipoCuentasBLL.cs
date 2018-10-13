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
    public class TipoCuentasBLL
    {
        public static bool Guardar(TipoCuentas tipoCuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.TipoCuenta.Add(tipoCuentas) != null)
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
                var eliminar = contexto.PreCuenta.Find(Id);
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

        public static bool Modificar(TipoCuentas tipoCuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(tipoCuentas).State = EntityState.Modified;
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

        public static TipoCuentas Buscar(int id)
        {
            TipoCuentas tipoCuentas = new TipoCuentas();
            Contexto contexto = new Contexto();
            try
            {
                tipoCuentas = contexto.TipoCuenta.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return tipoCuentas;
        }

        public static List<TipoCuentas> GetList(Expression<Func<TipoCuentas, bool>> tipo)
        {
            List<TipoCuentas> tipoCuentas = new List<TipoCuentas>();
            Contexto contexto = new Contexto();
            try
            {
                tipoCuentas = contexto.TipoCuenta.Where(tipo).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return tipoCuentas;
        }
    }
}
