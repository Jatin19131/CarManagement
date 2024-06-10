import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesCommissionReportComponent } from './sales-commission-report.component';

describe('SalesCommissionReportComponent', () => {
  let component: SalesCommissionReportComponent;
  let fixture: ComponentFixture<SalesCommissionReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SalesCommissionReportComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(SalesCommissionReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
