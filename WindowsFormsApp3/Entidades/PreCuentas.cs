using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.Entidades
{
    public class PreCuentas
    {
        [Key]
        public int PreCuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        public  List<PreCuentasDetalle> Detalle { get; set; }

        public PreCuentas()
        {
            this.PreCuentaId = 0;
            this.Fecha = DateTime.Now;
            this.Descripcion = string.Empty;
            this.Monto = 0;

            this.Detalle = new List<PreCuentasDetalle>();
        }

        public PreCuentas(int preCuentaId)
        {
            this.PreCuentaId = preCuentaId;
        }
    }
}
