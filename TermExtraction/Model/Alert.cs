using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TermExtraction.Model
{
    public class Alert
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("contents")]
        public List<AlertContent> contents { get; set; }
        [JsonProperty("date")]
        public DateTime date { get; set; }
        [JsonProperty("inputType")]
        public string inputType { get; set; }

        public Alert(string id, List<AlertContent> contents, DateTime date, string inputType)
        {
            this.id = id;
            this.contents = contents;
            this.date = date;
            this.inputType = inputType;
        }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}," + $"{nameof(contents)}: {contents}," + $"{nameof(date)}: {date}," + $"{nameof(inputType)}: {inputType}";
        }

        public class AlertContent
        {
            [JsonProperty("text")]
            public string text { get; set; }
            [JsonProperty("type")]
            public string type { get; set; }
            [JsonProperty("language")]
            public string language { get; set; }

            public AlertContent(string text, string type, string language)
            {
                this.text = text;
                this.type = type;
                this.language = language;
            }

            public override string ToString()
            {
                return $"{nameof(text)}: {text}, " + $"{nameof(type)}: {type}," + $"{nameof(language)}: {language}";
            }
        }
    }
}
