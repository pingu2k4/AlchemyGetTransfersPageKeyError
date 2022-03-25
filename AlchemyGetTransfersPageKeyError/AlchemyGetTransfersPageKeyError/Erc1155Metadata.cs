using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    public class Erc1155Metadata
    {
        [DataMember(Name = "tokenId")]
        public HexBigInteger TokenId { get; set; } = null!;

        [DataMember(Name = "value")]
        public HexBigInteger Value { get; set; } = null!;
    }
}
