using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ProductivitySchema
    {
        public string PersonName { get; set; }
        public string Date { get; set; }
        public string TaskDescription { get; set; }
        public string Duration { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DescriptionInfo { get; set; }
    }
}

/*
    Details for power query

    #"Converted to Table" = Table.FromList(Source, Splitter.SplitByNothing(), null, null, ExtraValues.Error),
    #"Expanded Column2" = Table.ExpandRecordColumn(#"Converted to Table", "Column1", {"PersonName", "Date", "TaskDescription", "Duration", "StartTime", "EndTime", "DescriptionInfo"}, {"PersonName", "Date", "TaskDescription", "Duration", "StartTime", "EndTime", "DescriptionInfo"})
in
    #"Expanded Column2" 
*/
