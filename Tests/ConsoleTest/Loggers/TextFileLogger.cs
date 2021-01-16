﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTest.Loggers
{
    internal class TextFileLogger : Logger
    {
        private readonly TextWriter _Writer;
        public TextFileLogger(string FileName) //запрашиваем имя файла
        {
            _Writer = File.CreateText(FileName);
           // ((StreamWriter)_Writer).AutoFlush = true;// автоматически сброс с буфера на диск
        }

        public override void Flush()
        {
            _Writer.Flush();// Сброс с буфера на диск
        }

        public override void Log(string txt)
        {
            _Writer.WriteLine(txt);
        }
        
    }
}