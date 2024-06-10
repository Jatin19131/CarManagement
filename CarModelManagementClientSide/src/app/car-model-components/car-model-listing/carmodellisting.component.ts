import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MasterService } from '../../service/master.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { CarModel } from 'src/models/carmodel';

@Component({
  selector: 'app-carmodellisting',
  templateUrl: './carmodellisting.component.html',
  styleUrls: ['./carmodellisting.component.css']
})
export class CarModelListingComponent implements OnInit {

  @ViewChild('content') popupview!: ElementRef;

  //local variables
  public carModels: CarModel[] = [];
  public filteredData: CarModel[] = [];
  public paginatedData: CarModel[] = [];

  //pagination variables
  public currentPage = 1;
  public itemsPerPage = 6;
  public totalPages = 1;
  public currentSortColumn: string | null = null;
  public currentSortDirection: 'asc' | 'desc' = 'asc';

  constructor(private service: MasterService,
    private alert: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadCarModels();
  }

  private loadCarModels() {
    this.service.getAllCarModel().subscribe((res: any) => {
      this.carModels = res;
      this.filteredData = [...this.carModels];
      this.totalPages = Math.ceil(this.filteredData.length / this.itemsPerPage);
      this.updatePaginatedData();
    });
  }

  //Search filter
  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.toLowerCase();
    this.filteredData = this.carModels.filter(carModel =>
      carModel.modelName.toLowerCase().includes(filterValue) ||
      carModel.modelCode.toLowerCase().includes(filterValue)
    );
    this.totalPages = Math.ceil(this.filteredData.length / this.itemsPerPage);
    this.currentPage = 1;
    this.updatePaginatedData();
  }
  //end

  //Sorting and pagination
  public sortData(column: string) {
    this.currentSortColumn = column;
    this.currentSortDirection = this.currentSortDirection === 'asc' ? 'desc' : 'asc';

    this.filteredData.sort((a, b) => {
      type CarModelKeys = keyof CarModel;
      const columnKey = column as CarModelKeys;
      if (a[columnKey] < b[columnKey]) {
        return this.currentSortDirection === 'asc' ? -1 : 1;
      } else if (a[columnKey] > b[columnKey]) {
        return this.currentSortDirection === 'asc' ? 1 : -1;
      } else {
        return 0;
      }
    });

    this.updatePaginatedData();
  }

  private updatePaginatedData() {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    this.paginatedData = this.filteredData.slice(start, end);
  }

  public nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.updatePaginatedData();
    }
  }

  public previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePaginatedData();
    }
  }
  //end

  public removeCarModel(carModelId: number) {
    if (carModelId != null && carModelId > 0) {
      this.service.deleteCarModelById(carModelId).subscribe((res: any) => {
        if (res) {
          this.alert.success('Car Model Removed Successfully', 'CarModel');
          this.loadCarModels();
        } else {
          this.alert.error('Failed to remove.', 'CarModel');
        }
      });
    }
  }

  public editCarModel(carModelId: number) {
    if (carModelId != null && carModelId > 0) {
      this.router.navigate(['/editcarmodel', carModelId]);
    }
  }
}
