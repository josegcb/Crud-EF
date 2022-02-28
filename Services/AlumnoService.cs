using CRUD.EntityFramework;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services {
    public class AlumnoService : ServiceBase<Alumno> {
        public AlumnoService(ApplicationDBContext context) : base(context) {
        }

        public Task<List<Alumno>> GetAll(string filter) {
            return Task.FromResult(_context.Alumnos
                .Include(p => p.Materias)
                .Where(p => p.Nombre.Contains(filter)).ToList());
        }
    }
}
