using ContactInformationCore.Interface;
using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

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

        public int DeleteContact(int id)
        {
            Contact contact = _dataContext.Contacts.Find(id);
            _dataContext.Contacts.Remove(contact);
            return _dataContext.SaveChanges();
        }

        public Contact ContactByID(int id)
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

        public void UpdateContact(Contact Contact)
        {
            try
            {
                if (Contact.First_Name != null)
                {
                    _dataContext.Entry(Contact).Property(x => x.First_Name).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Last_Name).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Email).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Phone_Number).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Status).IsModified = true;
                    _dataContext.SaveChanges();
                }
                else
                {
                    _dataContext.Contacts.Attach(Contact);
                    _dataContext.Entry(Contact).Property(x => x.First_Name).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Last_Name).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Email).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Phone_Number).IsModified = true;
                    _dataContext.Entry(Contact).Property(x => x.Status).IsModified = true;
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

        public IQueryable<Contact> ShowAllBookingUser(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableBooking = (from temp in _dataContext.Contacts
                                     select new Contact
                                     {
                                         Id = temp.Id,
                                         First_Name = temp.First_Name,
                                         Last_Name = temp.Last_Name,
                                         Email = temp.Email,
                                         Phone_Number = temp.Phone_Number,
                                         Status = temp.Status
                                     });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                IQueryableBooking = IQueryableBooking.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableBooking = IQueryableBooking.Where(m => m.Phone_Number == Search);
            }

            return IQueryableBooking;
        }

    }
}
