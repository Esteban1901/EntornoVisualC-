using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Inscripcion
    {
        public Recorrido Reco { get; set; }
        public Categoria Cate { get; set; }
        public string Identificador { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public double Valor { get; set; }
        public override string ToString()
        {
            return this.Reco + " \n" + this.Cate + " \n" + this.Valor + " \n" + this.Identificador + " \n" + this.FechaInscripcion + " \n" + this.Nombre + " \n" + this.Edad + " \n" + this.Email;
        }
    }
}
