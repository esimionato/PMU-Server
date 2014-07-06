﻿/*The MIT License (MIT)

Copyright (c) 2014 PMU Staff

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Server.Exceptions
{
    public class ErrorLogger
    {
        public static void WriteToErrorLog(Exception exception, string optionalInfo) {
            try {
                string date = DateTime.Now.ToShortTimeString();
                string filePath = IO.Paths.LogsFolder + "ErrorLog-" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
                using (StreamWriter writer = new StreamWriter(filePath, true)) {
                    writer.WriteLine("--- " + DateTime.Now.ToLongTimeString() + " ---");
                    writer.WriteLine("Exception: " + exception.ToString());
                    if (!string.IsNullOrEmpty(optionalInfo)) {
                        writer.WriteLine("Additional Data: " + optionalInfo);
                    }
                    writer.WriteLine();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void WriteToErrorLog(Exception exception) {
            WriteToErrorLog(exception, "");
        }

    }
}
