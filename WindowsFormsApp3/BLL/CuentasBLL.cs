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
    public class CuentasBLL
    {
        public static bool Guardar(Cuentas cuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Cuenta.Add(cuentas) != null)
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
                var eliminar = contexto.Cuenta.Find(Id);
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

        public static bool Modificar(Cuentas cuentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(cuentas).State = EntityState.Modified;
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

        public static Cuentas Buscar(int id)
        {
            Cuentas cuentas = new Cuentas();
            Contexto contexto = new Contexto();
            try
            {
                cuentas = contexto.Cuenta.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return cuentas;
        }

        public static List<Cuentas> GetList(Expression<Func<Cuentas, bool>> cuen)
        {
            List<Cuentas> cuentas = new List<Cuentas>();
            Contexto contexto = new Contexto();
            try
            {
                cuentas = contexto.Cuenta.Where(cuen).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return cuentas;
        }
    }
}
