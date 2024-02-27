using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Lab08_MVC.Controllers
{
    public class ToolController : Controller
    {
        public IActionResult Solve(double a, double b, double c) {

            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            ViewBag.result = GetResults(a, b, c);

            setClass(ViewBag.result);

            return View();
        }

        private void setClass(List<double> list)
        {
            if(list == null)
            {
                ViewBag.resultClass = "infinity";
                ViewBag.info = "Nieskończenie wiele rozwiązań";
            }
            else if(list.Count == 0) {
                ViewBag.resultClass = "zero-solutions";
                ViewBag.info = "Nie ma rozwiązań";
            }
            else if(list.Count == 1)
            {
                ViewBag.resultClass = "one-solution";
                ViewBag.info = "Jest 1 rozwiązanie";
            }
            else
            {
                ViewBag.resultClass = "two-solutions";
                ViewBag.info = "Są 2 rozwiązania";
            }
        }

        private List<double> GetResults(double a, double b, double c)
        {
            List<double> results = new List<double>();
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        results = null;
                    }
                    else
                    {
                    }

                }
                else
                {
                    results.Add(-c / b);
                }
            }
            else
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;
                if (delta > 0)
                {
                    double result1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double result2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    results.Add(result1);
                    results.Add(result2);
                }
                else if (delta == 0)
                {

                    results.Add(-b / (2 * a));
                }
                else
                {
                }
            }
            return results;
        }
    }
}
