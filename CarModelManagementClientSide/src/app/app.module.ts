import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddCarModelComponent } from './car-model-components/add-car-model/addcarmodel.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer'
import { DataTablesModule } from 'angular-datatables'
import { CarModelListingComponent } from './car-model-components/car-model-listing/carmodellisting.component';
import { DatePipe } from '@angular/common';
import { SalesCommissionReportComponent } from './sales-commission-report/sales-commission-report.component';

@NgModule({
  declarations: [
    AppComponent,
    CarModelListingComponent,
    AddCarModelComponent,
    SalesCommissionReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgbModule,
    NgxExtendedPdfViewerModule,
    DataTablesModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})

export class AppModule { }
