using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Entities
{
    public class UnderstandingMVCRepo : IUnderstandingMVCRepo
    {
        private readonly MvcContext _mvcContext;

        public UnderstandingMVCRepo(MvcContext mvcContext)
        {
            _mvcContext = mvcContext;
        }

        public void AddContactToDB(Contact result)
        {
            _mvcContext.Add(result);
        }

        public void AddEntity(object model)
        {
            _mvcContext.Add(model);
        }

        public void DeleteMessage(int id)
        {
            var ms = GetMessage(id);

            _mvcContext.Remove(ms); 
        }

        public void EditMessage(Contact contact)
        {
            var result = _mvcContext.Contacts.Where(id => id.ContactID == contact.ContactID).FirstOrDefault();

            if(result != null)
            {
                result.Name = contact.Name;
                result.Mail = contact.Mail;
                result.Message = contact.Message;
                result.Subject = contact.Subject;

            }

            



        }

        public IEnumerable<Contact> GetAllMessages()
        {
            return _mvcContext.Contacts.OrderBy(c => c.ContactID).ToList();
        }

        public IEnumerable<Product> GetAllProducts(bool inOrder)
        {
            if (inOrder)
            {
                return _mvcContext.Products.OrderBy(p => p.Title).ToList();
            }

            return _mvcContext.Products.ToList();
        }

        public Contact GetMessage(int id)
        {
            return _mvcContext.Contacts.Where(m => m.ContactID == id).FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return _mvcContext.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _mvcContext.Products.Where(p => p.Category == category).ToList();
        }

        //denne gemmer hvis mere end 0 rækker er blevet påvirket
        public bool SaveAll()
        {
            return _mvcContext.SaveChanges() > 0;
        }
    }
}
