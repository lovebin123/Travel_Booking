import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { createCarRentalBooking } from '../../../models/createCarRentalBooking';

@Injectable({
  providedIn: 'root'
})
export class CarRentalBookingService {
private url='http://localhost:5253/api/carRentalBooking';
  constructor(private http:HttpClient) { }
  createBooking(id:any,createCarRentalBooking:createCarRentalBooking):Observable<any>
  {
   
    return this.http.post(`${this.url}/createBooking?id=${id}`,createCarRentalBooking);
  }
  createCheckout(id:any):Observable<any>
  {
    return this.http.post(`${this.url}/create-session?bookingId=${id}`,{});
  }
  getUserBooking():Observable<any>
  {
  
    return this.http.get(`${this.url}/getUserBooking`);
  }
}
