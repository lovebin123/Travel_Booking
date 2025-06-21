import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Flight } from '../../models/flight';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
private jwtHelper=new JwtHelperService();
private url='http://localhost:5253/api/flights';
  constructor(private http:HttpClient,private router:Router) { }
getByQuery(flightData: any): Observable<any> {
  
  const queryParams = `?source=${flightData.source}&destination=${flightData.destination}&date_of_departure=${flightData.date_of_departure}&seatType=${flightData.seatType}`;
  return this.http.get<any[]>(this.url + '/getByQuery' + queryParams);
}
getAllFlights():Observable<any>
{
  const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.get(`${this.url}/getAllFlights`,{headers:headers});
}
getSources():Observable<any>
{
  return this.http.get(this.url+'/getSources');
}
getDestinations():Observable<any>
{
  return this.http.get(this.url+'/getDestinations');
}
createFlight(flightData:Flight):Observable<any>
{
  const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.post(`${this.url}/createFlight`,flightData,{headers:headers});
}
getById(id:any):Observable<any>
{
   const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.get(`${this.url}/getById?id=${id}`,{headers:headers});
}
updateFlight(id:any,flightData:Flight):Observable<any>
{
  const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.put(`${this.url}/updateFlight?id=${id}`,flightData,{headers:headers})
}
deleteById(id:any)
{
    const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.delete(`${this.url}/deleteFlight?id=${id}`,{headers:headers});
}
}
