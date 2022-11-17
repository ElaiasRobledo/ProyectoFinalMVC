using System;
using System.Collections.Generic;

namespace RedSocial.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Carrera carrera { get; set; }
        public string foto { get; set; }
        public DateTime FechaIngreso { get; set; }
      //  public List<Carrera> carrera { get; set; }



    }
}
