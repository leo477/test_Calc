using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calc.Models
{
    public class DataManager
    {
        private Database1Entities _db;
        
        public DataManager()
        {
            _db = new Database1Entities();
        }

        public IQueryable<Mathr> GetMathrs()
        {
            return _db.Mathrs;
        }
        

        
        public void SaveItem(string str)
        {
            Mathr ma = new Mathr();
             ma.res = str;
            ma.Id = Guid.NewGuid();
                _db.Mathrs.Add(ma);
                _db.SaveChanges();

        }


    }
}