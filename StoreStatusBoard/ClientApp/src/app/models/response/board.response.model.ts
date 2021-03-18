import { StockModel } from "../stock.model";

export interface BoardResponseModel {
  amount?: string;
  monitoringModels?: StockModel[];
}
