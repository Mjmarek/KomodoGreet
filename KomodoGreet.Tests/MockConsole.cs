﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoGreet.Contracts;

namespace KomodoGreet.Tests
{
    [ExcludeFromCodeCoverage]
    class MockConsole : IConsole
    {
        private readonly Queue<string> _userInput;
        public string Output { get; private set; }

        public MockConsole()
        {
            Output = string.Empty;
        }

        public MockConsole(IEnumerable<string> input)
        {
            _userInput = new Queue<string>(input);
            Output = string.Empty;
        }

        public void WriteLine(string message)
        {
            Output += message + "\r\n";
        }

        public void Write(string message)
        {
            Output += message;
        }
        public void WriteLine(object o)
        {
            Output += o.ToString() + "\r\n";
        }

        public string ReadLine()
        {
            return _userInput.Count == 0 ? string.Empty : _userInput.Dequeue();
        }

        public void Clear()
        {
            Output += "Clear screen";
        }
    }
}