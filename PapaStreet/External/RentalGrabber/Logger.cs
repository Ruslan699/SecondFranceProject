using System;
using System.Diagnostics;
using System.Threading;

namespace SiteGrabber
{
    public class Logger
    {
        public static void Write(string line,params object[] args)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (args.Length != 0) line = string.Format(line, args);
            Console.Write("[thread."+ threadId +"] "+ line);
            Debug.Write(line);
        }
        public static void WriteLine(string line, params object[] args)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            if (args.Length != 0) line = string.Format(line, args);
            Console.WriteLine("[thread." + threadId + "] " + line);
            Debug.WriteLine(line);
        }
    }
}