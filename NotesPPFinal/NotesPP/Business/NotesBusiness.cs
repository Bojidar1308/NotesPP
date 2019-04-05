using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesPP
{
    /// <summary>
    /// Клас <c>NotesBusiness</c>, кoйто е част от бизнес логиката и
    /// отговаря за обработката на бележките.
    /// </summary>
    /// <remarks>
    /// Той може да връща информация, да добавя, да актуализира и
    /// да изтрива бележки.
    /// </remarks>
    class NotesBusiness
    {
        private notesppContext notesppContext;

        /// <summary>
        /// Метод, връщащ всички бележки за потребителя който използва
        /// приложението в момента.
        /// </summary>
        /// <returns>
        /// Данните които връща са "Id", "Name", "Content".
        /// </returns>

        public List<Notes> GetAllNotes()
        {
            using (notesppContext = new notesppContext())
            {
                return notesppContext.Notes.ToList();
            }
        }
        
        /// <summary>
        /// Метод, който добавя нова бележка.
        /// </summary>
        /// <param name="note">
        /// Обект от типа Note, който е бележката която ще се добавя.
        /// </param>

        public void Add(Notes note)
        {
            using (notesppContext = new notesppContext())
            {
                notesppContext.Notes.Add(note);
                notesppContext.SaveChanges();
            }
        }

        /// <summary>
        /// Метод, който актуализира дадена бележка.
        /// </summary>
        /// <param name="note">
        /// Обект от типа Note, който е бележката която ще се актуализира.
        /// </param>

        public void Update(Notes note)
        {
            using (notesppContext = new notesppContext())
            {
                var item = notesppContext.Notes.Find(note.Id);
                if (item != null)
                {
                    notesppContext.Entry(item).CurrentValues.SetValues(note);
                    notesppContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод, който изтрива дадена бележка.
        /// </summary>
        /// <param name="id">
        /// Число от целочислен тип, което е номер на бележката
        /// която ще се изтрива.
        /// </param>

        public void Delete(int id)
        {
            using (notesppContext = new notesppContext())
            {
                var note = notesppContext.Notes.Find(id);
                if (note != null)
                {
                    notesppContext.Notes.Remove(note);
                    notesppContext.SaveChanges();
                }
            }
        }

        public Notes Get(int id)
        {
            using (notesppContext = new notesppContext())
            {
                return notesppContext.Notes.Find(id);
            }
        }
    }
}
