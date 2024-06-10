import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarModelListingComponent } from './car-model-components/car-model-listing/carmodellisting.component';
import { AddCarModelComponent } from './car-model-components/add-car-model/addcarmodel.component';
import { SalesCommissionReportComponent } from './sales-commission-report/sales-commission-report.component';

const routes: Routes = [
  { component: CarModelListingComponent, path: "" },
  { component: AddCarModelComponent, path: "addcarmodel" },
  { component: AddCarModelComponent, path: "editcarmodel/:carmodelid" },
  { component: SalesCommissionReportComponent, path: "salescommissionreport" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
