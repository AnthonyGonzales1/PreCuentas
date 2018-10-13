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
    public class PreCuentasBLL
    {
        public static bool Guardar(PreCuentas preCuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.PreCuenta.Add(preCuentas) != null)
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

        public static bool Modificar(PreCuentas preCuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(preCuentas).State = EntityState.Modified;
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

        public static PreCuentas Buscar(int id)
        {
            PreCuentas preCuentas = new PreCuentas();
            Contexto contexto = new Contexto();
            try
            {
                preCuentas = contexto.PreCuenta.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return preCuentas;
        }

        public static List<PreCuentas> GetList(Expression<Func<PreCuentas, bool>> precde)
        {
            List<PreCuentas> preCuentas = new List<PreCuentas>();
            Contexto contexto = new Contexto();
            try
            {
                preCuentas = contexto.PreCuenta.Where(precde).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return preCuentas;
        }
    }
}
