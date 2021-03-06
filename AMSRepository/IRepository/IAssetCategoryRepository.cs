﻿using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IAssetCategoryRepository
    {
        AssetCategory CreateAssetCategory(AssetCategory assetCategory);

        List<AssetCategory> GetAssetCategories();

        AssetCategory GetAssetCategoryByID(int assetCategoryID);

        AssetCategory UpdateAssetCategory(AssetCategory assetCategory);
    }
}