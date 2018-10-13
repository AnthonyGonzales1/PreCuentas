using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.Entidades
{
    public class TipoCuentas
    {
        public int TipoId { get; set; }
        public string Descripcion { get; set; }

        public TipoCuentas()
        {
            this.TipoId = 0;
            this.Descripcion = string.Empty;
        }

        public TipoCuentas(int tipoId, string descripcion)
        {
            this.TipoId = tipoId;
            this.Descripcion = descripcion;
        }
    }
}
