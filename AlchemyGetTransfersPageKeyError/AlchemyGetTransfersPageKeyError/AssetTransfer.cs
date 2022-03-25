using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    [DataContract]
    public class AssetTransfer
    {
        [DataMember(Name = "blockNum")]
        public HexBigInteger BlockNumber { get; set; } = null!;

        [DataMember(Name = "hash")]
        public string TransactionHash { get; set; } = null!;

        [DataMember(Name = "from")]
        public string FromAddress { get; set; } = null!;

        [DataMember(Name = "to")]
        public string ToAddress { get; set; } = null!;

        [DataMember(Name = "value")]
        public decimal? Value { get; set; }

        [DataMember(Name = "erc721TokenId")]
        public HexBigInteger? Erc721TokenId { get; set; }

        [DataMember(Name = "erc1155Metadata")]
        public List<Erc1155Metadata>? Erc1155Metadata { get; set; }

        [DataMember(Name = "tokenId")]
        public HexBigInteger? TokenId { get; set; }

        [DataMember(Name = "asset")]
        public string? Asset { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; } = null!;

        [DataMember(Name = "rawContract")]
        public AssetTransferRawContract RawContract { get; set; } = null!;
    }
}
