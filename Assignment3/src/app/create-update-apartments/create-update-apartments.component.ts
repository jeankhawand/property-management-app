import {Component, Inject, OnInit} from '@angular/core';
import {ApartmentsService} from "../shared/services/apartments.service";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {Apartment, Mode} from "../shared/models";
import {FormBuilder, FormGroup, RequiredValidator, Validators} from "@angular/forms";

@Component({
  selector: 'app-create-update-apartments',
  templateUrl: './create-update-apartments.component.html',
  styleUrls: ['./create-update-apartments.component.scss']
})
export class CreateUpdateApartmentsComponent implements OnInit {
  apartmentEditCreate : Apartment;
  constructor(@Inject(MAT_DIALOG_DATA) private data: { apartment: Apartment, mode: Mode },private apartmentService: ApartmentsService, public fb: FormBuilder) { }
  readonlyMode: boolean;
  submitButton: boolean;
  myForm: FormGroup;
  editButton: boolean;
  priceField: boolean;
  successMessage: boolean = false;
  ngOnInit(): void {
    this.reactiveForm();
    if(this.data.mode == Mode.create){

      this.apartmentEditCreate = {
        id: 1,
        title: "Awesome Apartment",
        address: "beirut",
        nbOfRooms:8
      }
      this.editButton = false;
      this.readonlyMode = false;
      this.submitButton = true;
      this.priceField = false;
    }
    if(this.data.mode == Mode.edit){
      this.editButton = true;
      this.readonlyMode = true;
      this.priceField = true;
      this.apartmentEditCreate = this.data.apartment;
    }

  }
  reactiveForm() {
    this.myForm = this.fb.group({
      title: ['',Validators.required],
      nbOfRooms: ['',Validators.required],
      address: ['',Validators.required],
      price: [''],

    })
  }
  saveApartment():void {
    if(this.data.mode == Mode.edit && !this.readonlyMode){
      this.apartmentService.update(this.apartmentEditCreate).subscribe(
        result => {
          this.successMessage = true;
          this.apartmentService.all();
        },
        error => console.log(error)
      )
    }
    if (this.data.mode == Mode.create){
      this.apartmentService.create(this.apartmentEditCreate).subscribe(
      result => {
        this.successMessage = true
        this.apartmentService.all()
      },
        error => console.log(error)
      )
    }
  }
  enableEditMode():void {
    console.log(this.successMessage)
    this.readonlyMode = false;
    this.submitButton = true;
  }
}
