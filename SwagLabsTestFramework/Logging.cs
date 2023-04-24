using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.DevTools.V104.Debugger;

namespace SwagLabsTestFramework
{
    public class Logging
    {
        [ThreadStatic]
        int step = 0;
        public Logging() { }

        public void LogTestStep(string text)
        {
            step++;
            Console.WriteLine($"Step {step}: "+text);
        }
    }
}
