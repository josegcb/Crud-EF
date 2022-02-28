using CRUD.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services {
    public class ServiceBase<T> where T : class {
        
        internal readonly ApplicationDBContext _context;

        public ServiceBase(ApplicationDBContext context) {
            _context = context;
        }

        public async Task<T> Save(T record) {
            _context.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<T> Update(T record) {
            _context.Update(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<bool> Delete(int id) {
            var record = await _context.FindAsync<T>(id);
            _context.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
