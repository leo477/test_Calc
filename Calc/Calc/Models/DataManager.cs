using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calc.Models
{
    public class DataManager
    {
        private Database1Entities _db;//Инициализируем наше соединение

        public DataManager()
        {
            _db = new Database1Entities();
        }

        public IQueryable<Mathr> GetMathrs()// Получаем набор из бд
        {
            return _db.Mathrs;//Возвращаем набор данных
        }



        public void SaveItem(string str)//сохранние в бд
        {
            Mathr ma = new Mathr();
            ma.res = str;
            ma.Id = Guid.NewGuid();//формируем новое id
            _db.Mathrs.Add(ma);
            _db.SaveChanges();//сохраняем изменения

        }


    }
}