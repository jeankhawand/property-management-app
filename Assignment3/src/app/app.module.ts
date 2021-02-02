import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { ApartmentsComponent } from './apartments/apartments.component';
import { PurchaseApartmentsComponent } from './purchase-apartments/purchase-apartments.component';
import {FormsModule} from "@angular/forms";
import {ApartmentsService} from "./shared/services/apartments.service";
import { CreateUpdateApartmentsComponent } from './create-update-apartments/create-update-apartments.component';
import {BuyersService} from "./shared/services/buyers.service";
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    ApartmentsComponent,
    PurchaseApartmentsComponent,
    CreateUpdateApartmentsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ApartmentsService,
    BuyersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
