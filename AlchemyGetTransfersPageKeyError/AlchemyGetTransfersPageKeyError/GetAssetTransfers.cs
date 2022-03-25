using Nethereum.JsonRpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyGetTransfersPageKeyError
{
    public class GetAssetTransfers : RpcRequestResponseHandler<AssetTransfers>
    {
        public GetAssetTransfers(IClient client) : base(client, "alchemy_getAssetTransfers")
        {
        }

        public Task<AssetTransfers> SendRequestAsync(AssetTransfersInput input, object? id = null)
        {
            return base.SendRequestAsync(id, input);
        }

        public RpcRequest BuildRequest(AssetTransfersInput input, object? id = null)
        {
            return base.BuildRequest(id, input);
        }
    }
}
