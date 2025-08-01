import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarRentalPaymentService {
private url="http://localhost:5253/api/carRentalPayment";
  constructor(private http:HttpClient) { }
  getLatestPayment(sessionId:any):Observable<any>
  {
    return this.http.get(`${this.url}/getLatestPayment?sessionId=${sessionId}`);
  }
  getAllPayments():Observable<any>
  {
    return this.http.get(`${this.url}/getAllPayments`);
  }
    getById(id:any):Observable<any>
  {
    return this.http.get(`${this.url}/getById?id=${id}`);
  }
}
