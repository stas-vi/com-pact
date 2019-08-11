﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ComPact.Models
{
    internal class MatchingRuleCollection
    {
        [JsonProperty("header")]
        internal Dictionary<string, MatcherList> Header { get; set; }
        [JsonProperty("body")]
        internal Dictionary<string, MatcherList> Body { get; set; }

        internal MatchingRuleCollection() { }

        internal MatchingRuleCollection(Dictionary<string, Matcher> matchingRules)
        {
            if (matchingRules == null)
            {
                throw new System.ArgumentNullException(nameof(matchingRules));
            }

            Body = new Dictionary<string, MatcherList>();
            foreach (var rule in matchingRules.Where(m => m.Key.StartsWith("$.body")))
            {
                Body.Add(rule.Key.Substring(7), new MatcherList { Matchers = new List<Matcher> { rule.Value } });
            }

            Header = new Dictionary<string, MatcherList>();
            foreach (var rule in matchingRules.Where(m => m.Key.StartsWith("$.headers")))
            {
                Header.Add(rule.Key.Substring(10), new MatcherList { Matchers = new List<Matcher> { rule.Value } });
            }
        }
    }

    internal class MatcherList
    {
        [JsonProperty("combine")]
        internal string Combine { get; set; } = "AND";
        [JsonProperty("matchers")]
        internal List<Matcher> Matchers { get; set; }
    }
}
