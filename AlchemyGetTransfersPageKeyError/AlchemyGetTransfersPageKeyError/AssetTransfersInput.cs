using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    [DataContract]
    public class AssetTransfersInput
    {
        public AssetTransfersInput()
        {
            FromBlock = null!;
            ToBlock = null!;
        }

        public AssetTransfersInput(BlockParameter fromBlock, BlockParameter toBlock)
        {
            FromBlock = fromBlock;
            ToBlock = toBlock;
        }

        public AssetTransfersInput(BlockParameter fromBlock, BlockParameter toBlock, string pageKey) : this(fromBlock, toBlock)
        {
            PageKey = pageKey;
        }

        [DataMember(Name = "fromBlock", EmitDefaultValue = false)]
        public BlockParameter FromBlock { get; set; }

        [DataMember(Name = "toBlock", EmitDefaultValue = false)]
        public BlockParameter ToBlock { get; set; }

        private string? _fromAddress;
        [DataMember(Name = "fromAddress", EmitDefaultValue = false)]
        public string? FromAddress
        {
            get => _fromAddress.EnsureHexPrefix();
            set => _fromAddress = value;
        }

        private string? _toAddress;
        [DataMember(Name = "toAddress", EmitDefaultValue = false)]
        public string? ToAddress
        {
            get => _toAddress.EnsureHexPrefix();
            set => _toAddress = value;
        }

        [DataMember(Name = "contractAddresses", EmitDefaultValue = false)]
        public List<string>? ContractAddresses { get; set; }

        [DataMember(Name = "maxCount", EmitDefaultValue = false)]
        public HexBigInteger? MaxCount { get; set; }

        [DataMember(Name = "pageKey", EmitDefaultValue = false)]
        public string? PageKey { get; set; }

        [DataMember(Name = "excludeZeroValue")]
        public bool ExcludeZeroValue { get; set; } = false;

        [DataMember(Name = "category", EmitDefaultValue = false)]
        public List<string>? Category { get; set; }

        [IgnoreDataMember]
        public static List<string> AllErcCategorys => new List<string> { "erc1155", "erc20", "erc721" };

        public static List<string> AllEthAndErcCategorys = new List<string> { "external", "internal", "erc1155", "erc20", "erc721" };
    }
}
