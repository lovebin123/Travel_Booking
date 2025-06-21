import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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
  postHotelBooking(id:any,no_of_rooms:any,no_of_adults:any,no_of_children:any,checkin_date:any,checkout_date:any):Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    })
    return this.http.post(`${this.url}/postBooking?id=${id}&no_of_rooms1=${no_of_rooms}&no_of_adults1=${no_of_adults}&no_of_children1=${no_of_children}&check_in_date=${checkin_date}&check_out_date=${checkout_date}`,{},{headers:headers});
  }
  createSession(id:any):Observable<any>
  {
    return this.http.post(`${this.url}/payment-session?id=${id}`,{});
  }
}
