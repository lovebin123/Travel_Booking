import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarRental } from '../../models/carRentals';

@Injectable({
  providedIn: 'root'
})
export class CarRentalService {
  constructor(private http:HttpClient) {}
  private url="http://localhost:5253/api/carRentals";
  getFromQuery(query:any):Observable<any>
  {
    return this.http.get(`${this.url}/getFromQuery?AvailableFromDate=${query.pickupdate}&AvailableUntilDate=${query.dropoffdate}&AvailableFromTime=${query.pickuptime}&AvailableUntilTime=${query.dropofftime}&location=${query.location}`);
  }
  getLocations():Observable<any>
  {
    return this.http.get(`${this.url}/getLocations`);
  }
  getAllCarRentals(pageNumber:number,pageSize:number):Observable<any>
  {
    
    return this.http.get(`${this.url}/getAllCarRentals?pageNumber=${pageNumber.toString()}&pageSize=${pageSize.toString()}`);
  }
  getById(id:any):Observable<any>
  {
    
    return this.http.get(`${this.url}/getById?id=${id}`);
  }
  createCarRental(carRentalData:CarRental)
  {
    return this.http.post(`${this.url}/createCarRental`,carRentalData);
  }
  searchByCarName(name:any):Observable<any>
  {
    return this.http.get(`${this.url}/searchByCarName?name=${name}`);
  }
updateCarRental(id:any,carRentalData:CarRental)
{
    return this.http.put(`${this.url}/updateCarRental?id=${id}`,carRentalData);
}
deleteCarRental(id:any)
{
    return this.http.delete(`${this.url}/deleteCarRental?id=${id}`);
}
}
