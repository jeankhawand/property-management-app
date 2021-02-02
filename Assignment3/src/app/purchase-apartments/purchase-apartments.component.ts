import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {ApartmentsService} from "../shared/services/apartments.service";
import {BuyersService} from "../shared/services/buyers.service";
import {Buyer} from "../shared/models/";
import {currencyFormatter} from "../shared/utils";

export interface DialogData {
  apartmentId: number;
}
@Component({
  selector: 'app-purchase-apartments',
  templateUrl: './purchase-apartments.component.html',
  styleUrls: ['./purchase-apartments.component.scss']
})
export class PurchaseApartmentsComponent implements OnInit {
  buyers: Buyer[];
  errorMessage: boolean;
  successMessage: boolean;
  selectedBuyer: number;
  currencyFormatter : any;
  constructor(
    public dialogRef: MatDialogRef<PurchaseApartmentsComponent>,
    @Inject(MAT_DIALOG_DATA) private data: DialogData, private apartmentsService: ApartmentsService, private buyersService: BuyersService ) {}

  ngOnInit(): void {
    this.currencyFormatter = currencyFormatter;
    this.buyersService.all().subscribe((buyerList)=> this.buyers = buyerList)

  }
  onNoClick(): void {
    this.errorMessage = false;
    this.dialogRef.close();
  }
  purchase(): void {
    this.buyersService.purchaseApartment(this.data.apartmentId, this.selectedBuyer)
      .subscribe(
        data => {
          this.successMessage = true;
        },
        error => {
          error.status == 404 ? this.errorMessage = true : null;
        }
      )};

}

