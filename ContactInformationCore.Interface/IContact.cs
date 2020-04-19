using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactInformationCore.Interface
{
    public interface IContact
    {
        void SaveContact(Contact Contact);
        //IQueryable<Contact> ShowContact(string sortColumn, string sortColumnDir, string Search);
        int DeleteContact(int? id);
        Contact ContactByID(int? id);
        void UpdateContact(Contact ContacttoUpdate, Contact Contact);
        //bool CheckEmailIsAlreadyExist(string DishName, string ContactType);
        List<Contact> GetAllContact();
        IEnumerable<Contact> ShowAllContact();

    }
}
