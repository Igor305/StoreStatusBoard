import { StockModel } from "./stock.model";

export interface ResponseModel {
  amount?: string;
  monitoringModelsR?: StockModel;
  monitoringModelsS?: StockModel;
}
