import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightBookingService {
private url='http://localhost:5253/api/flightBooking';

  constructor(private http:HttpClient) {}
postFlightBooking(id: any,no_of_adults:string,no_of_children:string): Observable<any> {
  console.log(id);
  const token = localStorage.getItem('token');
  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`,
  });
  return this.http.post(`${this.url}/postBooking?id=${id}&no_of_adults1=${no_of_adults}&no_of_children11=${no_of_children}`,  {},{headers:headers});
}
goToPayement(id:number):Observable<any[]>
{
  return this.http.post<any[]>(`${this.url}/payement-session?id=${id}`,{});
}
getUserBookings():Observable<any[]>{
  const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`,
  });
  return this.http.get<any[]>(this.url+'/getBookings',{headers:headers});
}
}
