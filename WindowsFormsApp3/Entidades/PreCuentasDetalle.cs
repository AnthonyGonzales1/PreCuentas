using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.Entidades
{
    public class PreCuentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        
        //[ForeignKey("CuentaId")]
        //public virtual Cuentas cuentas { get; set; }

        public PreCuentasDetalle()
        {
            Id = 0;
        }

        public PreCuentasDetalle(int id, string descripcion, int cuentaId, int valor)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.CuentaId = cuentaId;
            this.Valor = valor;
        }
    }
}
