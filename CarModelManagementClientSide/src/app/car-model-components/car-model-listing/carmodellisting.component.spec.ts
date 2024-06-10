import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CarModelListingComponent } from './carmodellisting.component';


describe('ListingComponent', () => {
  let component: CarModelListingComponent;
  let fixture: ComponentFixture<CarModelListingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarModelListingComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CarModelListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
