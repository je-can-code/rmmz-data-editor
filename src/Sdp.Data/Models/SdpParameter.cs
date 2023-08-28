using System.Text.Json.Serialization;
using JMZ.Sdp.Data.Services;

namespace JMZ.Sdp.Data.Models;

public class SdpParameter
{
    [JsonIgnore]
    public string ParameterName
    {
        get
        {
            //var name = ParameterMapper.NameFromLongParameterId(this.ParameterId);
            var name = ((LongParameter)this.ParameterId).ToString();

            if (!this.IsFlat)
            {
                name += " %";
            }

            if (this.IsCore)
            {
                name = $"✨{name}";
            }
            else
            {
                name = $"🔹{name}";
            }

            return name;
        }
    }

    public int ParameterId { get; set; } = 0;

    public decimal PerRank { get; set; } = 10;

    public bool IsFlat { get; set; } = true;

    public bool IsCore { get; set; } = false;
}