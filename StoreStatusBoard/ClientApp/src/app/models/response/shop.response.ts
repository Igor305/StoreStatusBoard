import { ProviderModel } from "../provider.model";

export interface ShopResponseModel {

  workTimeFrom?: Date;
  workTimeTo?: Date;
  region?: string;
  city?: string;
  street?: string;
  number?: string;
  providers?: ProviderModel;

}
