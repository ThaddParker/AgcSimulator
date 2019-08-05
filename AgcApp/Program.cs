using System;

namespace AgcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLineToConsole("Hello World!");
            WriteToConsole();
            Run();
        }

        static void Run(){
            while(true){
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)){ continue;}
                ParseConsoleInput(consoleInput);
            }
        }

        private static void ParseConsoleInput(string input)
        {
            var inpt = input.Split(new[]{' '});
            foreach(var inp in inpt)
            {

            }
        }

        static void WriteLineToConsole(string message=""){
            if(!string.IsNullOrWhiteSpace(message)){
                Console.WriteLine(message);
            }
        }
        static void WriteToConsole(string message=""){
            if(!string.IsNullOrWhiteSpace(message)){
                Console.Write(_readPrompt + message);
            }
            else
            {
                Console.Write(_readPrompt);
            }
        }
        
         const string _readPrompt = "console> ";

        public static string ReadFromConsole(string promptMessage = "")
        {
            // Show a prompt, and get input:
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }
    }


}
