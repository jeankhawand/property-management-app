import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";


@Injectable({
  providedIn: 'root'
})
export class BuyersService {
  private model = "Buyer";

  constructor(private http: HttpClient) { }
  all(): Observable<any>{
    return this.http.get(this.getUrl())
  }
  purchaseApartment(apartmentId:number, buyerId: number){
    return this.http.get(this.getUrl()+`/${buyerId}/Apartment/${apartmentId}`);
  }
  getUrl(){
    return `${environment.API_BASE_URL}${this.model}`;
  }

}


