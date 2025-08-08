import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hotel } from '../../common/models/hotels';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class HotelServiceService {
private url=`${environment.apiUrl}/v2/hotels`;
  constructor(private http:HttpClient) { }
  getHotelLocations():Observable<any>
  {
    return this.http.get(this.url+'/getLocations');
  }
  getHotelsFromQuery(location:any):Observable<any>
  {
    return this.http.get(`${this.url}/getHotelsFromQuery?location=${location}`);
  }
  searchByHotelName(name:any):Observable<any>
{
  return this.http.get(`${this.url}/searchByHotelName?name=${name}`);
}
  getAllHotels(page:number,pageSize:number):Observable<any>
  {
    return this.http.get(`${this.url}/getAllHotels?pageNumber=${pageSize.toString()}&pageSize=${page.toString()}`);
  }
  addHotel(hotelData:Hotel):Observable<any>
  {
  return this.http.post(`${this.url}/createHotel`,hotelData);
  }
  updateHotel(id:any,hotelData:any):Observable<any>
  {
  return this.http.put(`${this.url}/updateHotel?id=${id}`,hotelData);
  }
  deleteHotel(id:any):Observable<any>
  {
    return this.http.delete(`${this.url}/deleteHotel?id=${id}`);
  }
  getById(id:any):Observable<any>
  {
      
    return this.http.get(`${this.url}/getById?id=${id}`);
  }
}
