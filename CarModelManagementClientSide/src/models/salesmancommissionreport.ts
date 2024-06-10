export interface SalesmanCommissionReport {
  id: number;
  salesmanName: string;
  fixedCommissionAmount: number;
  classACommissionAmount: number;
  classBCommissionAmount: number;
  classCCommissionAmount: number;
  additionalCommission: number;
  overallCommission: number;
  month: number
  created: Date;
}