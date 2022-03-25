using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    [DataContract]
    public class AssetTransferRawContract
    {
        [DataMember(Name = "value")]
        public HexBigInteger? Value { get; set; }

        [DataMember(Name = "address")]
        public string? Address { get; set; }

        [DataMember(Name = "decimal")]
        public HexBigInteger? Decimal { get; set; }

        public decimal GetRealValue(int? decimals)
        {
            if (Value is null)
            {
                return 0;
            }

            if (decimals is null && Decimal is null)
            {
                return ((decimal) Value.Value);
            }

            var dec = decimals ?? (int) Decimal!.Value;

            return (decimal) UnitConversion.Convert.FromWeiToBigDecimal(Value.Value, dec);
        }
    }
}
