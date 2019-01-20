using System.Collections.Generic;

namespace UnderstandigMVC.Entities
{
    public interface IUnderstandingMVCRepo
    {
        IEnumerable<Product> GetAllProducts(bool inOrder);
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        Product GetProductById(int Id);
        void AddEntity(object model);
        void AddContactToDB(Contact result);
        IEnumerable<Contact> GetAllMessages();
        Contact GetMessage(int id);
        void EditMessage(Contact contact);
        void DeleteMessage(int id);
    }
}