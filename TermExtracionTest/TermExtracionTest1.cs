using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TermExtraction.Model;
using TermExtraction.Worker;
using Xunit.Sdk;

namespace TermExtracionTest
{
    [TestClass]
    public class TermExtracionTest
    {
        private List<QueryTerm> queryTerms;
        private List<Alert> alerts;

        #region Query setup
        //Fill term list with 1 term in EN 
        private void setUpQueries_1_false()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term", "en", false);
            queryTerms.Add(term1);
        }

        //Fill term list with 1 term in EN 
        private void setUpQueries_1_true()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term", "en", true);
            queryTerms.Add(term1);
        }

        private void setUpQueries_1_word()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "random", "en", true);
            queryTerms.Add(term1);
        }

        //Fill term list with 1 term (2 words) in EN 
        private void setUpQueries_2_false()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term match", "en", false);
            queryTerms.Add(term1);
        }

        //Fill term list with 1 term (2 words) in EN 
        private void setUpQueries_2_true()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term match", "en", true);
            queryTerms.Add(term1);
        }

        //Fill term list with 1 term in DE
        private void setUpQueries_1_true_DE()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term", "de", false);
            queryTerms.Add(term1);
        }

        //Fill term list with 2 terms in EN
        private void setUpQueries_2()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term", "en", false);
            QueryTerm term2 = new QueryTerm(2, "word", "en", false);

            queryTerms.Add(term1);
            queryTerms.Add(term2);
        }
        private void setUpQueries_2_2()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "rand", "en", false);
            QueryTerm term2 = new QueryTerm(2, "term", "en", false);

            queryTerms.Add(term1);
            queryTerms.Add(term2);
        }

        //Fill term list with 2 terms in EN/DE
        private void setUpQueries_2_EN_DE()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term", "de", false);
            QueryTerm term2 = new QueryTerm(2, "match", "en", false);

            queryTerms.Add(term1);
            queryTerms.Add(term2);
        }

        //Fill term list with 2 terms (2 length) in EN
        private void setUpQueries_2_2Length()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term the", "en", false);
            QueryTerm term2 = new QueryTerm(2, "the word", "en", true);

            queryTerms.Add(term1);
            queryTerms.Add(term2);

        }

        //Fill term list with 2 terms (2 length) in EN, keepOrder true for both
        private void setUpQueries_2_2KeepOrder()
        {
            queryTerms = new List<QueryTerm>();

            QueryTerm term1 = new QueryTerm(1, "term the", "en", true);
            QueryTerm term2 = new QueryTerm(2, "word term", "en", true);

            queryTerms.Add(term1);
            queryTerms.Add(term2);

        }
        #endregion

        #region Alert setup
        private void setUpAlert_1_term()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term", "short","en");
            contents.Add(alertContent);

            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            alerts.Add(alert);
        }

        private void setUpAlert_1_term_DE()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term", "short", "de");
            contents.Add(alertContent);

            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            alerts.Add(alert);
        }

        private void setUpAlert_1_2_nonConsecutively()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term and match", "short", "en");

            contents.Add(alertContent);

            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            alerts.Add(alert);
        }

        private void setUpAlert_1_2()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term match", "short", "en");

            contents.Add(alertContent);

            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            alerts.Add(alert);
        }

        private void setUpAlert_2()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term", "short", "en");
            contents.Add(alertContent);
            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            List<Alert.AlertContent> contents2 = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent2 = new Alert.AlertContent("The word is hello", "short", "en");
            contents2.Add(alertContent2);
            Alert alert2 = new Alert("alert2", contents2, DateTime.Now, "tweet");

            alerts.Add(alert);
            alerts.Add(alert2);
        }

        private void setUpAlert_2_sameWord()
        {
            alerts = new List<Alert>();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("The word is term", "short", "en");
            contents.Add(alertContent);
            Alert alert = new Alert("alert1", contents, DateTime.Now, "tweet");

            Alert alert2 = new Alert("alert2", contents, DateTime.Now, "tweet");

            alerts.Add(alert);
            alerts.Add(alert2);
        }

        private void setAlert_2_2()
        {
            setUpAlert_1_term();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("matches no word", "short", "en");
            contents.Add(alertContent);

            Alert alert = new Alert("alert2", contents, DateTime.Now, "tweet");

            alerts.Add(alert);

        }

        private void setAlert_2_3()
        {
            setAlert_2_2();

            List<Alert.AlertContent> contents = new List<Alert.AlertContent>();
            Alert.AlertContent alertContent = new Alert.AlertContent("term might be the word", "short", "en");
            contents.Add(alertContent);

            Alert alert = new Alert("alert3", contents, DateTime.Now, "tweet");

            alerts.Add(alert);

        }
        #endregion

        #region Tests
        //Simple match 1 term to alert
        [TestMethod]
        public void Match_1_1_Term()
        {
            setUpQueries_1_true();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].alertId, "alert1");
            Assert.AreEqual(result[0].termId, 1);
        }

        //Different language, alert in DE
        [TestMethod]
        public void Match_1_1_Term_EN_DE()
        {
            setUpQueries_1_true();
            setUpAlert_1_term_DE();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Different language, query term in DE
        [TestMethod]
        public void Match_1_1_Term_DE_EN()
        {
            setUpQueries_1_true_DE();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Term is not on alert
        [TestMethod]
        public void Match_1_1_Word()
        {
            setUpQueries_1_word();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Simple match 1 term to alert, keep order false, result should mantain
        [TestMethod]
        public void Match_1_1_Term_false()
        {
            setUpQueries_1_false();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].alertId, "alert1");
            Assert.AreEqual(result[0].termId, 1);
        }

        //Two word on query term, only match 1 in alert
        [TestMethod]
        public void Match_1_2_Term_noMatch()
        {
            setUpQueries_2_true();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Two word on query term, match 2 on alert, but not consecutively 
        [TestMethod]
        public void Match_1_2_Term_nonConsecutively()
        {
            setUpQueries_2_true();
            setUpAlert_1_2_nonConsecutively();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Two word on query term, nonConsecutively, but keepOrder false
        [TestMethod]
        public void Match_1_2_Term_False()
        {
            setUpQueries_2_false();
            setUpAlert_1_2_nonConsecutively();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].alertId, "alert1");
            Assert.AreEqual(result[0].termId, 1);
        }

        //Two word on query term, match 2 on alert
        [TestMethod]
        public void Match_1_2_Term()
        {
            setUpQueries_2_true();
            setUpAlert_1_2();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].termId, 1);
            Assert.AreEqual(result[0].alertId, "alert1");
        }

        //Simple match 1 term to 2 alerts
        [TestMethod]
        public void Match_1_1_Term_2()
        {
            setUpQueries_1_true();
            setUpAlert_2();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].alertId, "alert1");
            Assert.AreEqual(result[0].termId, 1);
        }

        //Simple match 1 term to 2 alerts
        [TestMethod]
        public void Match_1_1_Term_2_sameWord()
        {
            setUpQueries_1_true();
            setUpAlert_2_sameWord();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 2);
        }

        //Simple match 2 term to 1 alerts
        [TestMethod]
        public void Match_2_1_Term()
        {
            setUpQueries_2();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 2);
        }

        //Simple match 2 term to 1 alerts, one term match
        [TestMethod]
        public void Match_2_1_Term_2()
        {
            setUpQueries_2_2();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].termId, 2);
            Assert.AreEqual(result[0].alertId, "alert1");
        }

        //Simple match 2 term to 1 alert,different language
        [TestMethod]
        public void Match_2_1_Term_EN_DE()
        {
            setUpQueries_2_EN_DE();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Simple match 2 (2 words each) term to 1 alert
        [TestMethod]
        public void Match_2_1_Term_2Length()
        {
            setUpQueries_2_2Length();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 2);
        }

        //Simple match 2 (2 words each) term to 1 alert
        [TestMethod]
        public void Match_2_1_Term_2KeepOrder()
        {
            setUpQueries_2_2KeepOrder();
            setUpAlert_1_term();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 0);
        }

        //Simple match 2 (2 words each) term to 2 alert
        [TestMethod]
        public void Match_2_2_Term()
        {
            setUpQueries_2_2Length();
            setAlert_2_2();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 2);
        }

        //Simple match 2 (2 words each) term to 3 alert, will find 4 matches
        [TestMethod]
        public void Match_2_3_Term()
        {
            setUpQueries_2_2Length();
            setAlert_2_3();

            TermMatcher termMatcher = new TermMatcher();
            List<MatchingId> result = termMatcher.matchTerm(alerts, queryTerms);
            Assert.AreEqual(result.Count, 4);

            int alert1Count = 0, alert2Count = 0, alert3Count = 0;
            int term1Count = 0, term2Count = 0;

            foreach(MatchingId id in result) {
                if (id.alertId == "alert1")
                {
                    alert1Count++;
                }else if (id.alertId == "alert2")
                {
                    alert2Count++;
                }else if(id.alertId == "alert3") 
                {
                    alert3Count++;
                }

                if(id.termId == 1)
                {
                    term1Count++;
                }else if (id.termId == 2)
                {
                    term2Count++;
                }
            }

            Assert.AreEqual(alert1Count, 2);
            Assert.AreEqual(alert2Count, 0);
            Assert.AreEqual(alert3Count, 2);
            Assert.AreEqual(term1Count, 2);
            Assert.AreEqual(term2Count, 2);

        }




        #endregion
    }
}
