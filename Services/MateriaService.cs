using CRUD.EntityFramework;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services {
    public class MateriaService : ServiceBase<Materia> {
        public MateriaService(ApplicationDBContext context) : base(context) {
        }

        public Task<List<Materia>> GetAll(string filter) {
            return Task.FromResult(_context.Materias
                .Include(p => p.Profesor)
                .Where(p => p.Nombre.Contains(filter) || p.Profesor.Nombre.Contains(filter) ).ToList());
        }
    }
}
