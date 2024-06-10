import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup, FormControl } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { MasterService } from '../../service/master.service';
import { ToastrService } from 'ngx-toastr'
import { CarBrands } from 'src/models/carbrands';
import { CarClasses } from 'src/models/carclasses';
import { CarModel } from 'src/models/carmodel';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-addcarmodel',
  templateUrl: './addcarmodel.component.html',
  styleUrls: ['./addcarmodel.component.css']
})
export class AddCarModelComponent implements OnInit {

  @Input() data: any;
  //Local variables
  public carModelForm: FormGroup;
  public pagetitle = "Add Car Model"
  public carBrands: CarBrands[] = [];
  public carClasses: CarClasses[] = [];
  public carModelId: string | null = "";
  public isSubmitted: boolean = false;
  //end

  constructor(private fb: FormBuilder,
    private service: MasterService,
    private router: Router,
    private alert: ToastrService,
    private activeroute: ActivatedRoute) {

    //Intialize form
    this.carModelForm = this.fb.group({
      brandControl: new FormControl(null, [Validators.required]),
      classControl: new FormControl(null, [Validators.required]),
      modelNameControl: new FormControl('',[Validators.required]),
      modelCodeControl: new FormControl('',[Validators.required]),
      descriptionControl: new FormControl('',[Validators.required]),
      featuresControl: new FormControl('',[Validators.required]),
      priceControl: new FormControl(0,[Validators.required]),
      dateOfManufacturingControl: new FormControl('',[Validators.required]),
      isActiveControl: new FormControl(false,[]),
      imagesControl: this.fb.array([])
    });
    //end

  }

  ngOnInit(): void {
    this.getDropdownsData();
    this.carModelId = this.activeroute.snapshot.paramMap.get('carmodelid');
    if (this.carModelId != null) {
      this.getCarmodel(this.carModelId);
    }
  }

  private getDropdownsData() {
    this.getCarBrands();
    this.getCarClasses();
  }

  private getCarBrands() {
    this.service.getCarBrands().subscribe((res: any) => {
      this.carBrands = res;
    });
  }

  private getCarClasses() {
    this.service.getCarClasses().subscribe((res: any) => {
      this.carClasses = res;
    });
  }

  public onFileSelected(event: any) {
    const files = event.target.files;
    if (files.length > 0) {
      const imagesArray = this.carModelForm.get('imagesControl') as FormArray;
      imagesArray.clear();
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.readAsDataURL(files[i]);
        reader.onload = () => {
          imagesArray.push(this.fb.control({ url: reader.result }));
        };
      }
    }
  }

  public saveCarModel() {
    this.isSubmitted = true;
    if (this.carModelForm.valid) {
      this.service.saveCarModel(this.sanatizeForm()).subscribe(res => {
        if (res) {
          if (this.carModelId == null || this.carModelId == '') {
            this.alert.success('Car Model Created Successfully', 'CarModel');
          } else {
            this.alert.success('Car Model Updated Successfully', 'CarModel');
          }
          this.router.navigate(['/']);
        } else {
          this.alert.error('Failed to save.', 'CarModel');
        }
      });
    } else {
      this.alert.warning('Please enter values in all mandatory filed', 'Validation');
    }
  }

  private sanatizeForm() {
    // Value of Form
    const formValue = this.carModelForm.value;

    // Extract day, month, and year from dateOfManufacturingControl, with fallbacks if not provided
    const day: number = formValue.dateOfManufacturingControl?.day ?? 0;
    const month: number = (formValue.dateOfManufacturingControl?.month ?? 0) - 1;
    const year: number = formValue.dateOfManufacturingControl?.year ?? 0;

    // Extract image URLs or base64 encoded image data from imagesControl
    const images: string[] = formValue.imagesControl.map((image: any) => {
      return image.url;
    });

    const selectedBrand = this.carBrands.find(x => x.brandId == formValue.brandControl);
    const selectedClass = this.carClasses.find(x => x.classId == formValue.classControl);

    //Creating model
    const newModel = {
      id: this.carModelId ?? 0,
      brandId: formValue.brandControl,
      carBrands: selectedBrand,
      classId: formValue.classControl,
      carClasses: selectedClass,
      modelName: formValue.modelNameControl,
      modelCode: formValue.modelCodeControl,
      description: formValue.descriptionControl,
      features: formValue.featuresControl,
      price: parseInt(formValue.priceControl),
      dateOfManufacturing: new Date(year, month, day) ?? new Date(),
      active: formValue.isActiveControl,
      images: images
    } as CarModel;

    return newModel
  }

  private getCarmodel(carModelId: string) {
    this.service.getCarModelById(parseInt(carModelId)).subscribe((res: any) => {
      if (res) {
        debugger
        this.setForm(res);
      } else {
        this.alert.error('No result found.', 'CarModel');
      }
    });
  }

  private setForm(data: CarModel) {

    // Extract the year, month, and day from the Date object and create an NgbDateStruct
    const date = new Date(data.dateOfManufacturing);
    const selectedDate: NgbDateStruct = {
      year: date.getFullYear(),
      month: date.getMonth() + 1,
      day: date.getDate()
    };

    //Patching value to form
    this.carModelForm.patchValue({
      brandControl: data.carBrands.brandId,
      classControl: data.carClasses.classId,
      modelNameControl: data.modelName,
      modelCodeControl: data.modelCode,
      descriptionControl: data.description,
      featuresControl: data.features,
      priceControl: data.price.toString(),
      dateOfManufacturingControl: selectedDate,
      isActiveControl: data.active,
      //imagesControl: imagesFormArray
    });


    // Add images to the form array
    (this.carModelForm.get('imagesControl') as FormArray).clear();
    data.images.forEach(imageUrl => {
      const imageFormGroup = new FormGroup({
        url: new FormControl(imageUrl)
      });
      (this.carModelForm.get('imagesControl') as FormArray).push(imageFormGroup);
    });
    //end
  }
}
