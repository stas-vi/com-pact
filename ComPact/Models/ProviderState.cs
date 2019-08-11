﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComPact.Models
{
    internal class ProviderState
    {
        [JsonProperty("name")]
        internal string Name { get; set; }
        [JsonProperty("params")]
        internal Dictionary<string, string> Params { get; set; }
    }
}
