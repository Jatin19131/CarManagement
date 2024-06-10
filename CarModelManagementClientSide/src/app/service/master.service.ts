import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { CarModel } from 'src/models/carmodel';

@Injectable({
  providedIn: 'root'
})

export class MasterService {

  constructor(private http: HttpClient) { }

  //Car Model
  public getAllCarModel() {
    return this.http.get(`${environment.ApibaseUrl}/CarModels`);
  }

  public saveCarModel(carModelData: CarModel) {
    return this.http.post(`${environment.ApibaseUrl}/CarModels/AddCarModel`, carModelData);
  }

  public getCarModelById(id: number) {
    return this.http.get(`${environment.ApibaseUrl}/CarModels/GetCarModelById/${id}`);
  }

  public deleteCarModelById(id: number) {
    return this.http.get(`${environment.ApibaseUrl}/CarModels/DeletCarModelById/${id}`);
  }
  //end

  public getCarBrands() {
    return this.http.get(`${environment.ApibaseUrl}/CarBrands`);
  }

  public getCarClasses() {
    return this.http.get(`${environment.ApibaseUrl}/CarClasses`);
  }

  public getSalesmanCommissionReport() {
    return this.http.get(`${environment.ApibaseUrl}/SalesReport/GetSalesmanCommissionReport`);
  }

}
