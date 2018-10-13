using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.Entidades
{
    public class Cuentas
    {
        [Key]
        public int CuentaId { get; set; }
        public int TipoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        
        public Cuentas()
        {
            this.CuentaId = 0;
            this.TipoId = 0;
            this.Descripcion = string.Empty;
            this.Monto = 0;
        }

        public Cuentas(int cuentaId, int tipoId, string descripcion, decimal Monto)
        {
            CuentaId = 0;
            TipoId = 0;
            Descripcion = string.Empty;
            Monto = 0;
        }
    }
}
