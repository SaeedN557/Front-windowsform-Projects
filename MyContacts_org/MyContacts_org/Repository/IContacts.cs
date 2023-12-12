using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContacts_org.Repository
{
    internal interface IContacts
    {
        DataTable SelectAll();  
        DataTable Selector(int contactId);
        DataTable search(string parameter);
        bool insert(string name, string family, string mobile, int age);
        bool update(string name, string family, string mobile, int age);
        bool delete(int contactId);
        
    }
}
