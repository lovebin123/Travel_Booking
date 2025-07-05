import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { createHotelBooking } from '../../../models/createHotelBooking';

@Injectable({
  providedIn: 'root'
})
export class HotelBookingServiceService {
  constructor(private http:HttpClient) { }
  private url='http://localhost:5253/api/hotelBooking';
  getUserBookings():Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.get(`${this.url}/getUserBookings`,{headers:headers});
  }
  postHotelBooking(id:any,createHotelBooking:createHotelBooking):Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    })
    return this.http.post(`${this.url}/postBooking?id=${id}`,createHotelBooking,{headers:headers});
  }
  createSession(id:any):Observable<any>
  {
    return this.http.post(`${this.url}/payment-session?id=${id}`,{});
  }
}
