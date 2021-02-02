import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ApartmentsComponent} from "./apartments/apartments.component";

const routes: Routes = [
  {path: "apartments", component: ApartmentsComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
