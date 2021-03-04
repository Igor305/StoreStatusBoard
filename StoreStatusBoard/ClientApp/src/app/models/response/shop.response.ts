import { ProviderModel } from "../provider.model";

export interface ShopResponseModel {

  WorkTimeFrom?: Date;
  WorkTimeTo?: Date;
  Region?: string;
  City?: string;
  Street?: string;
  Number?: string;
  Provider?: ProviderModel;

}
