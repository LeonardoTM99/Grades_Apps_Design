using Grades.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grades.Controllers
{
    public class SubjectsController : Controller
    {
        // Lista estática para simular una base de datos en memoria
        private static List<Subject> subjects = new List<Subject>
        {
            new Subject { Id = 1, Name = "Matemáticas" },
            new Subject { Id = 2, Name = "Historia" },
            new Subject { Id = 3, Name = "Ciencias" }
        };

        // GET: Subjects (Lista de materias)
        public ActionResult Index()
        {
            return View(subjects);
        }

        // GET: Subjects/Create (Formulario de creación)
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create (Agregar materia)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.Id = subjects.Count > 0 ? subjects.Max(s => s.Id) + 1 : 1; // Generar ID automático
                subjects.Add(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5 (Formulario de edición)
        public ActionResult Edit(int id)
        {
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // POST: Subjects/Edit/5 (Actualizar materia)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                var existingSubject = subjects.FirstOrDefault(s => s.Id == subject.Id);
                if (existingSubject != null)
                {
                    existingSubject.Name = subject.Name;
                }
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5 (Confirmación de eliminación)
        public ActionResult Delete(int id)
        {
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // POST: Subjects/Delete/5 (Eliminar materia)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subject = subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null) subjects.Remove(subject);
            return RedirectToAction("Index");
        }
    }
}
