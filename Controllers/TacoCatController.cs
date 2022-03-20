using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TacoCatMVC.Models;

namespace SmallMVCApps.Controllers
{
    public class TacoCatController : Controller
    {
        [HttpGet]
        public IActionResult Reverse()
        {
            Palindrome model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reverse(Palindrome palindrome)
        {
            string inputWord = palindrome.InputWord;
            string revWord = "";

            for (int i = inputWord.Length - 1; i >= 0; i--)
            {
                revWord += inputWord[i];
            }

            palindrome.RevWord = revWord;

            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-Z0-9]+", "");

            if (inputWord == revWord)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = $"Success {palindrome.InputWord} is a Palindrome";
            }
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = $"Sorry {palindrome.InputWord} is not a Palindrome";
            }

            return View(palindrome);
        }
    }
}
