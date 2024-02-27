using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Lab08_MVC.Controllers
{
    public class GameController : Controller
    {
        private const string RangeSessionKey = "Range";
        private const string GuessCountSessionKey = "GuessCount";
        private const string RandValueSessionKey = "RandValue";

        public IActionResult Guess([FromRoute] int value)
        {
            int range = GetSessionInt(RangeSessionKey);
            int guessCount = GetSessionInt(GuessCountSessionKey);
            int randValue = GetSessionInt(RandValueSessionKey);

            guessCount++;
            if (value == randValue)
            {
                ViewBag.info = $"Odgadnio liczbę w {guessCount} próbach";
                guessCount = 0;
            }
            else if (value > randValue)
            {
                ViewBag.info = $"Poszukiwana liczba jest mniejsza niż {value}";
            }
            else
            {
                ViewBag.info = $"Poszukiwana liczba jest większa niż {value}";
            }

            SetSessionInt(GuessCountSessionKey, guessCount);
            ViewBag.guessCount = guessCount;

            return View();
        }

        public IActionResult Set([FromRoute] int n)
        {
            SetSessionInt(RangeSessionKey, n);
            SetSessionInt(GuessCountSessionKey, 0);
            SetSessionInt(RandValueSessionKey, randValueToGuess(n));

            ViewBag.info = $"Ustawiono zakres na {n}.";
            ViewBag.guessCount = 0;
            ViewBag.range = n;

            return View();
        }

        public IActionResult Draw()
        {
            int range = GetSessionInt(RangeSessionKey);
            SetSessionInt(RandValueSessionKey, randValueToGuess(range));
            SetSessionInt(GuessCountSessionKey, 0);

            ViewBag.guessCount = 0;
            ViewBag.info = $"Wylosowano liczbę z zakresu 0-{range - 1}";

            return View();
        }

        private int randValueToGuess(int range)
        {
            Random rand = new Random();
            return rand.Next(0, range);
        }

        private int GetSessionInt(string key)
        {
            return HttpContext.Session.GetInt32(key) ?? 0;
        }

        private void SetSessionInt(string key, int value)
        {
            HttpContext.Session.SetInt32(key, value);
        }
    }
}
