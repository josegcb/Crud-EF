using CRUD.EntityFramework;
using CRUD.Models;
using CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            var context = new ApplicationDBContext();
            var profesorService = new ProfesorService(context);
            var materiaService = new MateriaService(context);
            var alumnoService = new AlumnoService(context);
            var profesor = profesorService.Save(new Profesor() { Nombre = RandomString(5) }).Result;
            var materia = materiaService.Save(new Materia() { ProfesorId = profesor.Id, Nombre = RandomString(10), NotaMinima = new Random().Next(10, 20) }).Result;
            var alumno = alumnoService.Save(new Alumno() { Nombre = RandomString(10), Materias = GenerateMaterias(materiaService) }).Result;
            Listado(alumnoService);
            Update(alumnoService);
            Delete(alumnoService);
            Console.WriteLine("**********----------------------****************");
            Listado(alumnoService);
            Console.ReadLine();

        }

        private static void Delete(AlumnoService alumnoService) {
            var list = alumnoService.GetAll("").Result;
            if (list.Count > 3) {
                int index = new Random().Next(list.Count);
                var x = alumnoService.Delete(list[index].Id).Result;
            }
        }

        private static void Update(AlumnoService alumnoService) {
            var list = alumnoService.GetAll("").Result;
            int index = new Random().Next(list.Count);
            list[index].Nombre += " Modificado";
            var x = alumnoService.Update(list[index]).Result;

        }

        private static void Listado(AlumnoService alumnoService) {
            foreach (var item in alumnoService.GetAll("").Result) {
                Console.WriteLine("Alumno: " + item.Nombre);
                Console.WriteLine("Materias:");
                foreach (var itemDetalle in item.Materias) {
                    Console.Write("        * Materia: " + itemDetalle.Materia.Nombre);
                    Console.WriteLine("        * Profesor: " + itemDetalle.Materia.Profesor.Nombre);
                }
                Console.WriteLine("**********");
            }
        }

        private static ICollection<Alumno_Materia> GenerateMaterias(MateriaService materiaService) {
            List<Alumno_Materia> List = new List<Alumno_Materia>();
            var listMaterias = materiaService.GetAll("").Result;
            int index = new Random().Next(listMaterias.Count)+1;
            for (int i = 0; i < index; i++) {
                List.Add(new Alumno_Materia() { MateriaId = listMaterias[i].Id });
            }
            return List;
        }

        public static string RandomString(int length) {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
