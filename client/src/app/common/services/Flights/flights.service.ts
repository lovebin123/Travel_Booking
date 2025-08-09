import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, Subject } from 'rxjs';
import { Flight } from '../../models/flight';
import { ResponseFlightDto } from '../../../../ap-api-client-angular';
import { environment } from '../../../../environments/environment.development';
import { AutoWrapperResponse } from '../../models/response';


@Injectable({
  providedIn: 'root'
})
export class FlightsService {
private jwtHelper=new JwtHelperService();
private readonly url=`${environment.apiUrl}/v1/flights`;
constructor(private http:HttpClient,private router:Router) { }
getByQuery(flightData: any): Observable<AutoWrapperResponse<ResponseFlightDto[]>> {
  
  const queryParams = `?source=${flightData.source}&destination=${flightData.destination}&date_of_departure=${flightData.date_of_departure}&seatType=${flightData.seatType}`;
  return this.http.get<AutoWrapperResponse<ResponseFlightDto[]>>(this.url + '/getByQuery' + queryParams);
}
getAllFlights(page:number,pageSize:number):Observable<AutoWrapperResponse<ResponseFlightDto[]>>
{
  return this.http.get<AutoWrapperResponse<ResponseFlightDto[]>>(`${this.url}/getAllFlights?pageNumber=${page.toString()}&pageSize=${pageSize.toString()}`);
}
searchByFlightName(name:any):Observable<AutoWrapperResponse<ResponseFlightDto>>
{
  return this.http.get<AutoWrapperResponse<ResponseFlightDto>>(`${this.url}/searchByFlightName?name=${name}`)
}
getSources():Observable<any>
{
  return this.http.get(this.url+'/getSources');
}
getDestinations():Observable<any>
{
  return this.http.get(this.url+'/getDestinations');
}
createFlight(flightData:Flight):Observable<AutoWrapperResponse<ResponseFlightDto>>
{
  return this.http.post<AutoWrapperResponse<ResponseFlightDto>>(`${this.url}/createFlight`,flightData);
}
getById(id:any):Observable<AutoWrapperResponse<ResponseFlightDto>>
{
  return this.http.get<AutoWrapperResponse<ResponseFlightDto>>(`${this.url}/getById?id=${id}`);
}
updateFlight(id:any,flightData:Flight):Observable<AutoWrapperResponse<ResponseFlightDto>>
{
  return this.http.put<AutoWrapperResponse<ResponseFlightDto>>(`${this.url}/updateFlight?id=${id}`,flightData)
}
deleteById(id:any)
{
  return this.http.delete(`${this.url}/deleteFlight?id=${id}`);
}
}
