import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelPaymentService {
  constructor(private http:HttpClient) {}
  private url="http://localhost:5253/api/hotelPayement"
  getLatest(sessionID:any):Observable<any>
  {
    return this.http.get(`${this.url}/getLastPayment?sessionId=${sessionID}`);
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
