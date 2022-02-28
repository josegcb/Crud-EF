using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models {
    public class Materia {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal NotaMinima { get; set; }
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
