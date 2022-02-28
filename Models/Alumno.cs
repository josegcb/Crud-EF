using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models {
    public class Alumno {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Alumno_Materia> Materias { get; set; }

    }
}
