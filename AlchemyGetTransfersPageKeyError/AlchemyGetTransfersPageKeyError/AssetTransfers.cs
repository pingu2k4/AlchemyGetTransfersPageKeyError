using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    [DataContract]
    public class AssetTransfers
    {
        [DataMember(Name = "transfers")]
        public List<AssetTransfer> Transfers { get; set; } = null!;

        [DataMember(Name = "pageKey")]
        public string? PageKey { get; set; }
    }
}
