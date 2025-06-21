import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarRentalBookingService {
private url='http://localhost:5253/api/carRentalBooking';
  constructor(private http:HttpClient) { }
  createBooking(id:any,pickupDate:any,dropoffDate:any,pickupTime:any,dropoffTime:any,diff:any):Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.post(`${this.url}/createBooking?id=${id}&pickupDate=${pickupDate}&dropoffDate=${dropoffDate}&pickupTime=${pickupTime}&dropoffTime=${dropoffTime}&diff=${diff}`,{},{headers:headers});
  }
  createCheckout(id:any):Observable<any>
  {
    return this.http.post(`${this.url}/create-session?bookingId=${id}`,{});
  }
  getUserBooking():Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.get(`${this.url}/getUserBooking`,{headers:headers});
  }
}
