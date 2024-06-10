import { Component, OnInit } from '@angular/core';
import { MasterService } from '../service/master.service';
import { SalesmanCommissionReport } from 'src/models/salesmancommissionreport';

@Component({
  selector: 'app-sales-commission-report',
  templateUrl: './sales-commission-report.component.html',
  styleUrls: ['./sales-commission-report.component.css']
})

export class SalesCommissionReportComponent implements OnInit {

  //local variables
  public salesmanCommissionReportData: SalesmanCommissionReport[] = [];
  public salesmanCommissionReportfilteredData: SalesmanCommissionReport[] = [];
  public salesmanCommissionReportpaginatedData: SalesmanCommissionReport[] = [];

  //pagination variables
  public currentPage = 1;
  public itemsPerPage = 6;
  public totalPages = 1;
  public currentSortColumn: string | null = null;
  public currentSortDirection: 'asc' | 'desc' = 'asc';

  constructor(private service: MasterService) { }

  ngOnInit(): void {
    this.loadSalesmanCommissionReport();
  }

  private loadSalesmanCommissionReport() {
    this.service.getSalesmanCommissionReport().subscribe((res: any) => {
      this.salesmanCommissionReportData = res;
      this.salesmanCommissionReportfilteredData = [...this.salesmanCommissionReportData];
      this.totalPages = Math.ceil(this.salesmanCommissionReportfilteredData.length / this.itemsPerPage);
      this.updatePaginatedData();
    });
  }

  //Search filter
  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.toLowerCase();
    this.salesmanCommissionReportfilteredData = this.salesmanCommissionReportData.filter(carModel =>
      carModel.salesmanName.toLowerCase().includes(filterValue)
    );
    this.totalPages = Math.ceil(this.salesmanCommissionReportfilteredData.length / this.itemsPerPage);
    this.currentPage = 1;
    this.updatePaginatedData();
  }
  //end

  //Sorting and pagination
  public sortData(column: string) {
    this.currentSortColumn = column;
    this.currentSortDirection = this.currentSortDirection === 'asc' ? 'desc' : 'asc';

    this.salesmanCommissionReportfilteredData.sort((a, b) => {
      type SalesManCommissionKeys = keyof SalesmanCommissionReport;
      const columnKey = column as SalesManCommissionKeys;
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
    this.salesmanCommissionReportpaginatedData = this.salesmanCommissionReportfilteredData.slice(start, end);
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

}
