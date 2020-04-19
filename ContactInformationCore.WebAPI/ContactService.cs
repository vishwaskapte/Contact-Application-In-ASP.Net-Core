using ContactInformationCore.Interface;
using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactInformationCore.WebAPI
{
    public class ContactService : IContact
    {
        readonly DatabaseContaxt _dataContext;

        public ContactService(DatabaseContaxt context)
        {
            _dataContext = context;
        }


        public void SaveContact(Contact Contact)
        {
            _dataContext.Contacts.Add(Contact);
            _dataContext.SaveChanges();
        }

        public int DeleteContact(int? id)
        {
            Contact contact = _dataContext.Contacts.Find(id);
            _dataContext.Contacts.Remove(contact);
            return _dataContext.SaveChanges();
        }

        public Contact ContactByID(int? id)
        {
            try
            {
                return _dataContext.Contacts.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateContact(Contact ContacttoUpdate, Contact Contact)
        {
            try
            { 
                if (ContacttoUpdate != null)
                {
                    Contact.First_Name = ContacttoUpdate.First_Name;
                    Contact.Last_Name = ContacttoUpdate.Last_Name;
                    Contact.Email = ContacttoUpdate.Email;
                    Contact.Phone_Number = ContacttoUpdate.Phone_Number;
                    Contact.Status = ContacttoUpdate.Status;

                    //Commit the transaction
                    _dataContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckEmailIsAlreadyExist(string Email)
        {
            var EmailCount = (from email in _dataContext.Contacts
                              where email.Email == Email
                              select email).Count();

            if (EmailCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Contact> GetAllContact()
        {
            var ContactList = (from contact in _dataContext.Contacts
                               select new Contact
                               {
                                   Id = contact.Id,
                                   First_Name = contact.First_Name,
                                   Last_Name = contact.Last_Name,
                                   Email = contact.Email,
                                   Phone_Number = contact.Phone_Number,
                                   Status = contact.Status
                               }).ToList();

            return ContactList;
        }

        public IEnumerable<Contact> ShowAllContact()
        {

            var ContactList = (from contact in _dataContext.Contacts
                               select new Contact
                               {
                                   Id = contact.Id,
                                   First_Name = contact.First_Name,
                                   Last_Name = contact.Last_Name,
                                   Email = contact.Email,
                                   Phone_Number = contact.Phone_Number,
                                   Status = contact.Status
                               }).ToList();

            return ContactList;
        }

        

    }
}
