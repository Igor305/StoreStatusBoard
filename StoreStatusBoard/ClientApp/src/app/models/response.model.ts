import { StockModel } from "./stock.model";

export interface ResponseModel {
  amount?: string;
  monitoringModels?: StockModel;
}
