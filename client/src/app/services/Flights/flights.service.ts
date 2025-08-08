import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, Subject } from 'rxjs';
import { Flight } from '../../common/models/flight';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
private jwtHelper=new JwtHelperService();
private readonly url=`${environment.apiUrl}/v1/flights`;
constructor(private http:HttpClient,private router:Router) { }
getByQuery(flightData: any): Observable<any> {
  
  const queryParams = `?source=${flightData.source}&destination=${flightData.destination}&date_of_departure=${flightData.date_of_departure}&seatType=${flightData.seatType}`;
  return this.http.get<any[]>(this.url + '/getByQuery' + queryParams);
}
getAllFlights(page:number,pageSize:number):Observable<any>
{
  return this.http.get(`${this.url}/getAllFlights?pageNumber=${page.toString()}&pageSize=${pageSize.toString()}`);
}
searchByFlightName(name:any):Observable<any>
{
  return this.http.get(`${this.url}/searchByFlightName?name=${name}`)
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
  return this.http.post(`${this.url}/createFlight`,flightData);
}
getById(id:any):Observable<any>
{
  return this.http.get(`${this.url}/getById?id=${id}`);
}
updateFlight(id:any,flightData:Flight):Observable<any>
{
  return this.http.put(`${this.url}/updateFlight?id=${id}`,flightData)
}
deleteById(id:any)
{
  return this.http.delete(`${this.url}/deleteFlight?id=${id}`);
}
}
