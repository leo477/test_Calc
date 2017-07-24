using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace Calc.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult ViewR()//Описываем экшн для отображения данных из БД
        {
            DataManager db = new DataManager();//обьявляем новый экземпляр модели данных
            ViewBag.Items = db.GetMathrs();
            return View();
        }
       
        
        public ActionResult Calc(string arg1, string arg2, string math) //Экшн для вьювера с расчтами
        {
            Calc.Models.TResult vdata = new Models.TResult()
            {
                arg1 = arg1,
                arg2 = arg2,
                math = math,
            };
            // обьявление переменных
            decimal a = 0;
            decimal b = 0;
            string result = "";
            //проверка на числа
            if (!decimal.TryParse(arg1, out a) || !decimal.TryParse(arg2, out b))
                result = "введите данные";
            // оператор с выбором операций
            switch (math)
            {
                case "+":
                    result = (a + b).ToString();
                    break;
                case "-":
                    result = (a - b).ToString();
                    break;
                case "*":
                    result = (a * b).ToString();
                    break;
                case "/":
                    result = b != 0 ?
                    (a / b).ToString()
                    : "error"; // исключениеесли деленение на 0
                    break;
                default:
                    result = "введите данные";// пока не введены корректные данные
                    break;
            }
            if (result != "введите данные" && result != "error" && result!="") //result 
            {
                        DataManager db = new DataManager();
                         db.SaveItem(a + math + b + "=" + result);//оьправка на сохранение
                    }
            vdata.result = result;
            return View(vdata);
        }
        

    }
}
