using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TermExtraction.Http;
using TermExtraction.Model;
using TermExtraction.Worker;

namespace TermExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ConsoleTarget
            {
                Name = "console",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}",
            };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget, "*");
            LogManager.Configuration = config;


            Console.WriteLine("Hello World!");
            HttpRequestHandler requestHandler = new HttpRequestHandler();
            TermMatcher termMatcher = new TermMatcher();

            List<Alert> alerts = requestHandler.GetAlerts();
            List<QueryTerm> queryTerms = requestHandler.GetQueryTerms();

            //Results are stored in this list, and are also printed to Console.
            List<MatchingId> matchingIds = termMatcher.matchTerm(alerts, queryTerms);

            Console.WriteLine("Bye World!");
            Console.Read();


        }
    }
}
