using ContactBook.Models;
using ContactBook.Interface;
namespace ContactBook.Service
{
    public class ContactService : Interface.IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }
        public Contact Add(Contact contact)
        {
            var book = new Entities.Contact();
            book.FirstName = contact.FirstName;
            book.LastName = contact.LastName;  
            book.Email = contact.Email;
            book.FullName = contact.FirstName + " " + contact.LastName;

            _context.Add(book);
            _context.SaveChanges();

            return contact;
        }   

        public bool Delete(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            _context.Contacts.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Contact> GetAll() {
            var contacts = _context.Contacts.ToList();
            var modelList = new List<Contact>();
            for (int i = 0; i < contacts.Count; i++)
            {
                var model = new Contact();
                model.Id = contacts[i].Id;
                model.FirstName = contacts[i].FirstName;
                model.LastName = contacts[i].LastName;
                model.Email = contacts[i].Email;
                modelList.Add(model);
            }

            return modelList;
        }

        public Contact GetById(int id)
        {
            var book = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return new Contact();
            }  
            var model = new Contact();
            model.Id = book.Id;
            model.FirstName = book.FirstName;
            model.LastName = book.LastName;
            model.Email = book.Email;

            return model;

        }

        public Contact Update(Contact contact)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (entity == null)
            {
                return new Contact();
            }

            entity.FirstName = contact.FirstName;
            entity.LastName = contact.LastName;
            entity.Email = contact.Email;
            entity.FullName = contact.FirstName + " " + contact.LastName;

            _context.Contacts.Update(entity);
            _context.SaveChanges();
            return contact;
        }
    }
}
