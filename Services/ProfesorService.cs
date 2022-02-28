using CRUD.EntityFramework;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services {
    public class ProfesorService : ServiceBase<Profesor> {
        public ProfesorService(ApplicationDBContext context) : base(context) {
        }

        public Task<List<Profesor>> GetAll(string filter) {
            return Task.FromResult(_context.Profesores.Where(p => p.Nombre.Contains(filter)).ToList());
        }
    }
}
