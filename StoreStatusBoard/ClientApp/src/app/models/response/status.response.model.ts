import { StockModel } from "../stock.model";

export interface StatusResponseModel {
  provider1: StockModel;
  provider2: StockModel;
  sunc: StockModel;
}
