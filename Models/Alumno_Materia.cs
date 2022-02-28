using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models {
    public class Alumno_Materia {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }
        public virtual Alumno Alumno { get; set; }
        public virtual Materia Materia { get; set; }

    }
}
