
namespace TermExtraction.Model
{
    public class MatchingId
    {
        public int termId { get; set; }
        public string alertId { get; set; }

        public MatchingId(int termId, string alertId)
        {
            this.termId = termId;
            this.alertId = alertId;
        }

        public override string ToString()
        {
            return $"{nameof(termId)}: {termId}," + $"{nameof(alertId)}: {alertId}";
        }
    }
}
