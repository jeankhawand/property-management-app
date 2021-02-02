import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from "@angular/material/paginator";
import {MatTableDataSource} from "@angular/material/table";
import {PurchaseApartmentsComponent} from "../purchase-apartments/purchase-apartments.component";
import {MatDialog} from "@angular/material/dialog";
import {ApartmentsService} from "../shared/services/apartments.service";
import {CreateUpdateApartmentsComponent} from "../create-update-apartments/create-update-apartments.component";
import {Search, Apartment, Mode} from "../shared/models/";
import {currencyFormatter} from "../shared/utils/index";
@Component({
  selector: 'app-apartments',
  templateUrl: './apartments.component.html',
  styleUrls: ['./apartments.component.scss']
})
export class ApartmentsComponent implements AfterViewInit {
  displayedColumns: string[] = ['id', 'title', 'address', 'NbOfRooms', 'price', 'purchase'];
  dataSource = new MatTableDataSource();
  currencyFormatter: any;
  public apartmentSearch:Search = this.apartmentsService.defaultSearch;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private apartmentsService: ApartmentsService,public dialog: MatDialog) {
  }
  ngAfterViewInit() {
    this.fetchApartments();
    this.dataSource.paginator = this.paginator;
    this.currencyFormatter = currencyFormatter;
  }
  fetchApartments(): void {
    this.apartmentsService.all().subscribe((apartments) =>{
      this.dataSource.data = apartments.data;
    })
  }
  OpenDialog(id: number): void {

    let dialogRef = this.dialog.open(PurchaseApartmentsComponent, {
      data: {apartmentId: id},
      height: '50vh',
      width: '40vh',
    });
    dialogRef.afterClosed().subscribe(
      data => this.fetchApartments(),
      error => console.log(error)
    )
  }
  openCreateDialog(): void {
    let dialogRef = this.dialog.open(CreateUpdateApartmentsComponent, {
      data: {mode: Mode.create},
      height: '50vh',
      width: '40vh',
    })
    dialogRef.afterClosed().subscribe(
      data => this.fetchApartments(),
      error => console.log(error)
    )
  }
  openUpdateDialog(apartment: Apartment): void {
    let dialogRef = this.dialog.open(CreateUpdateApartmentsComponent, {
      data: {apartment: apartment, mode: Mode.edit},
      height: '50vh',
      width: '40vh',
    })
    dialogRef.afterClosed().subscribe(
      data => this.fetchApartments(),
      error => console.log(error)
    )
  }
  searchApartment(){
    this.apartmentsService.filterApartment(this.apartmentSearch).subscribe(
      result => this.dataSource.data = result.data,
        error => console.log(error)
    )
  }



}


