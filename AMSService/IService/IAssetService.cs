using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSService.IService
{
    public interface IAssetService
    {
        List<AssetModel> GetAssets();

        AssetModel GetAssetByID(int Id);

        int AssignAsset(AssetModel assetModel);

        void UnassignAsset(AssetModel assetModel);
    }
}
