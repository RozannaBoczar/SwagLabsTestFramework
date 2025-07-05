using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.DevTools.V104.Debugger;
using System.Runtime.CompilerServices;

namespace SwagLabsTestFramework
{
    public class Logging
    {
        [ThreadStatic]
        public int step = 0;
        public Logging() {}

        public void LogTestStep(string text)
        {
            step++;
            Console.WriteLine($"Step {step}: "+text);
        }

        public void Clear() {
            step = 0;
        }
    }
}
