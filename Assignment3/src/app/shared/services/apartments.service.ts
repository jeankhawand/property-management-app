import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {Apartment} from "../models/Apartment";
import {Search} from "../models/Search";
// use dotenv
@Injectable({
  providedIn: 'root'
})
export class ApartmentsService {

  private model = "Apartment";
  public defaultSearch : Search = {
    priceFrom: 0,
    priceTo: 120000,
    address: "",
    numberOfRooms: 4
  };
  constructor(private http: HttpClient) { }

  /**
   * fetch all apartments
   */
  all(): Observable<any>{
    return this.http.get(this.getUrl())
  }
  find(apartmentId: number){}
  create(apartment: Apartment){
    return this.http.post(this.getUrl(), apartment);
  }
  update(apartment: Apartment){
    return this.http.put(this.getUrl()+`/${apartment.id}`, apartment);
  }
  getUrl(){
    return `${environment.API_BASE_URL}${this.model}`;
  }

  /**
   * search for apartment based on specific parameters
   * @param search
   */
  filterApartment(search: Search):Observable<any> {
    let params = new HttpParams();
    search.numberOfRooms != 0 ? params=params.append("numberOfRooms", String(search.numberOfRooms)): null;
    search.address !== "" ? params=params.append("address", String(search.address)): null;
    search.priceTo !== null ? params=params.append("toPrice", String(search.priceTo)): null;
    search.priceFrom !== null ? params=params.append("fromPrice", String(search.priceFrom)): null;
    return this.http.get(this.getUrl(),{
      params
    })
  }

}

