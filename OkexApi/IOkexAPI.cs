using OkexApi.OkexDTOs;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OkexApi
{
    public interface IOkexAPI
    {
        [Get("/api/spot/v3/accounts")]
        Task<IEnumerable<AssetModel>> GetAssetsAsync();
    }
}
