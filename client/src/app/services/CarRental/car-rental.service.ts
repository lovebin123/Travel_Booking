import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarRental } from '../../models/carRentals';

@Injectable({
  providedIn: 'root'
})
export class CarRentalService {
  constructor(private http:HttpClient) {}
  private url="http://localhost:5253/api/carRentals";
  getFromQuery(query:any):Observable<any>
  {
    return this.http.get(`${this.url}/getFromQuery?AvailableFromDate=${query.pickupdate}&AvailableUntilDate=${query.dropoffdate}&AvailableFromTime=${query.pickuptime}&AvailableUntilTime=${query.dropofftime}&location=${query.location}`);
  }
  getLocations():Observable<any>
  {
    return this.http.get(`${this.url}/getLocations`);
  }
  getAllCarRentals():Observable<any>
  {
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.get(`${this.url}/getAllCarRentals`,{headers:headers});
  }
  getById(id:any):Observable<any>
  {
     const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.get(`${this.url}/getById?id=${id}`,{headers:headers});
  }
  createCarRental(carRentalData:CarRental)
  {
      const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.post(`${this.url}/createCarRental`,carRentalData,{headers:headers});
  }
updateCarRental(id:any,carRentalData:CarRental)
{
    const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.put(`${this.url}/updateCarRental?id=${id}`,carRentalData,{headers:headers});
}
deleteCarRental(id:any)
{
   const token=localStorage.getItem('token');
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${token}`
    });
    return this.http.delete(`${this.url}/deleteCarRental?id=${id}`,{headers:headers});
}
}
