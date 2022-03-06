using MVCAssign.Models;
using System.Collections.Generic;
using System;
namespace MVCAssign.Service
{
    public interface IPeople
    {
        public List<PersonModel> GetAll();
        public void Create(PersonModel model);
        public void Update(PersonModel person);
         public PersonModel Detail(int ID);
          public PersonModel Delete(int id);
    }
}