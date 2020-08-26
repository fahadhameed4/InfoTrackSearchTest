using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSearchTest.Models
{
    public class ATagscs
    {
        public Dictionary<string, string> Attributes { get; private set; }
        public string InnerText { get; set; }
        /// <summary>
        /// Constructor 
        /// </summary>
        public ATagscs()
        {
            Attributes = new Dictionary<string, string>();
        }
        /// <summary>
        /// ToString() method to get values for InnerText and Attributes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("InnerText: " + InnerText);
            sb.AppendLine("Attributes:");
            foreach (var attribute in Attributes)
                sb.AppendLine("\t" + attribute.Key + "=" + attribute.Value);
            return sb.ToString();
        }

    }
}
