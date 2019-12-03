﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AMSRepository.Models;
using AMSUtilities.Models;

namespace AMSService.Service
{
  public  interface IComponentAssetMappingService
    {
        ComponentAssetMappingModel AssignComponents(ComponentAssetMappingModel componentAssetMappingModel);
        int CreateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);
        int CreateComponentMapping(ComponentAssetMappingModel componentAssetMappingModel);
        List<ComponentAssetMappingModel> GetComponentAssetMappings();
        List<ComponentAssetMappingModel> GetComponentAssetMappingsByAssetID(int assetID);
        ComponentAssetMappingModel GetComponentByID(int id);
        ComponentAssetMappingModel GetComponentModel(ComponentAssetMapping componentmapping);
        SelectList GetDropdownAssets(int ID,int selectedId = -1);
        ComponentAssetMappingModel UnassignComponents(ComponentAssetMappingModel componentAssetMappingModel);
        int UpdateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);
    }
}
