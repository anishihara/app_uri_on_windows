using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application_Url
{
    class Program
    {
        static void Main(string[] args)
        {
            string appPath = Environment.GetCommandLineArgs()[0];
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("appurltest");  //open appurltest subkey
            if (key == null)  // checks if the protocol is already registered
            {
                key = Registry.ClassesRoot.CreateSubKey("appurltest");
                key.SetValue(string.Empty, "URL: appurltest Protocol");
                key.SetValue("URL Protocol", string.Empty);
                key = key.CreateSubKey(@"shell\open\command");
                key.SetValue(string.Empty, appPath + " " + "%1");
                //%1 is the argument that will be passed to the application
            }
            key.Close();

            if(args[0].Contains("appurltest:"))
            {
                Console.WriteLine("Argument: " + args[0].Replace("appurltest:", string.Empty));
            }
            else
            {
                Console.WriteLine("No arguments.");
            }
            Console.ReadLine();
        }

    }
}
