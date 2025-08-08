import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class FlightBookingService {
  private url=`${environment.apiUrl}/flightBooking`
  constructor(private http:HttpClient) {}
postFlightBooking(id: any,no_of_adults:string,no_of_children:string): Observable<any> {
  console.log(id);
  return this.http.post(`${this.url}/postBooking?id=${id}&no_of_adults1=${no_of_adults}&no_of_children11=${no_of_children}`,  {},);
}
goToPayement(id:number):Observable<any[]>
{
  return this.http.post<any[]>(`${this.url}/payement-session?id=${id}`,{});
}
getUserBookings():Observable<any[]>{
  return this.http.get<any[]>(this.url+'/getBookings');
}
deleteById(id:any):Observable<any>
{
  return this.http.delete(`${this.url}/deleteById?id=${id}`);
}
}
