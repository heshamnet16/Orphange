using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrphansRegistries
{
    public interface Person
    {
         int Id{get;set;}
         string Name { get; set; }
         DateTime Birthday {get;set;}
         bool Save();
         bool Delete();
    }
}
