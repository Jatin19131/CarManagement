import { CarBrands } from "./carbrands";
import { CarClasses } from "./carclasses";

export interface CarModel {
  id: number;
  brandId: number;
  carBrands: CarBrands;
  classId: number;
  carClasses: CarClasses;
  modelName: string;
  modelCode: string;
  description: string;
  features: string;
  price: number;
  dateOfManufacturing: Date;
  active: boolean;
  created: Date;
  updated: Date;
  images: string[];
}