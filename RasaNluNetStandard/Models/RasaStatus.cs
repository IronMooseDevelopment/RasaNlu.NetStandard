/*-------------------------------------------------------------------------------------
  (C) 2019 Johnson Controls International Plc.
      All rights reserved. This software constitutes the trade secrets and confidential
      and proprietary information of Johnson Controls International Plc. It is intended
      solely for use by Johnson Controls International Plc. This code may not be copied
      or redistributed to third parties without prior written authorization from
      Johnson Controls International Plc.
-------------------------------------------------------------------------------------*/

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace IronMooseDevelopment.RasaNlu.Models
{
    [DebuggerDisplay("{CurrentTrainingProcesses} training out of {MaxTrainingProcesses} max")]
    public partial class RasaStatus
    {
        [JsonProperty("max_training_processes")]
        public long MaxTrainingProcesses { get; set; }

        [JsonProperty("current_training_processes")]
        public long CurrentTrainingProcesses { get; set; }

        [JsonProperty("available_projects")]
        public Dictionary<string, Project> AvailableProjects { get; set; }
    }

    [DebuggerDisplay("{Status}")]
    public partial class Project
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("current_training_processes")]
        public long CurrentTrainingProcesses { get; set; }

        [JsonProperty("available_models")]
        public List<string> AvailableModels { get; set; }

        [JsonProperty("loaded_models")]
        public List<string> LoadedModels { get; set; }
    }
}
