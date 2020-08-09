
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TermExtraction.Model;



/*
 Assumptions
    - The contents List on the alert will always only contain on element of "AlertContent"
    - Word case (upper/lower) in query terms and alerts don't matter
 */
namespace TermExtraction.Worker
{
    public class TermMatcher
    {
        Logger log = LogManager.GetCurrentClassLogger();

        public List<MatchingId> matchTerm(List<Alert> alertList, List<QueryTerm> termList)
        {
            string[] words;
            List<MatchingId> matchingIds = new List<MatchingId>();
            foreach (QueryTerm term in termList)
            {
                //if keepOrder false, then check if text contains seperate instance of the words in no particular order (e.g. "IG" + "metall")
                if (!term.keepOrder) { 
                    words = term.text.Split(' ');
                }
                else
                {
                    //if keepOrder true, then check for the whole sentence together (e.g. "IG metall")
                    words = new string[] { term.text };
                }

                //turn all to lowercase
                words = words.Select(s => s.ToLowerInvariant()).ToArray();

                //Cycle through alert, check if language matches, match words with text
                foreach (Alert alert in alertList)
                {
                    if(term.language == alert.contents[0].language)
                    {
                        if (words.All(alert.contents[0].text.ToLowerInvariant().Contains)) //Lowercase too
                        {
                            matchingIds.Add(new MatchingId(term.id, alert.id));
                            Console.WriteLine("ALERT ID: " + alert.id + " TERM ID: " + term.id);
                        }
                    }
                }
            }
            return matchingIds;
        }
    }
}
