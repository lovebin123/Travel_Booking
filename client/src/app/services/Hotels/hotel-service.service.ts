import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hotel } from '../../models/hotels';

@Injectable({
  providedIn: 'root'
})
export class HotelServiceService {
private url="http://localhost:5253/api/hotels";
  constructor(private http:HttpClient) { }
  getHotelLocations():Observable<any>
  {
    return this.http.get(this.url+'/getLocations');
  }
  getHotelsFromQuery(location:any):Observable<any>
  {
    return this.http.get(`${this.url}/getHotelsFromQuery?location=${location}`);
  }
  getAllHotels():Observable<any>
  {
    const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
    return this.http.get(`${this.url}/getAllHotels`,{headers:headers});
  }
  addHotel(hotelData:Hotel):Observable<any>
  {
      const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.post(`${this.url}/createHotel`,hotelData,{headers:headers});
  }
  updateHotel(id:any,hotelData:any):Observable<any>
  {
  const token=localStorage.getItem('token');
  const headers=new HttpHeaders({
    'Authorization':`Bearer ${token}`
  });
  return this.http.put(`${this.url}/updateHotel?id=${id}`,hotelData,{headers:headers});
  }
  deleteHotel(id:any):Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.delete(`${this.url}/deleteHotel?id=${id}`,{headers:headers});
  }
  getById(id:any):Observable<any>
  {
        const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.get(`${this.url}/getById?id=${id}`,{headers:headers});
  }
}
