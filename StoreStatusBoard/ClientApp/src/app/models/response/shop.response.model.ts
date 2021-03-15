import { ProviderModel } from "../provider.model";

export interface ShopResponseModel {

  workTimeFrom?: string;
  workTimeTo?: string;
  region?: string;
  city?: string;
  street?: string;
  number?: string;
  providers?: ProviderModel;

}
