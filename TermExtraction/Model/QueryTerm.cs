using Newtonsoft.Json;
using System;

namespace TermExtraction.Model
{
    public class QueryTerm
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("language")]
        public string language { get; set; }
        [JsonProperty("keepOrder")]
        public bool keepOrder { get; set; }

        public QueryTerm(int id, string text, string language, bool keepOrder)
        {
            this.id = id;
            this.text = text;
            this.language = language;
            this.keepOrder = keepOrder;
        }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}," + $"{nameof(text)}: {text}," + $"{nameof(language)}: {language}," + $"{nameof(keepOrder)}: {keepOrder}";
        }
    }
}
