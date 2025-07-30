import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightPaymentService {
  constructor(private http:HttpClient) { }
  private url="http://localhost:5253/api/payments";
  getLastPayement(sessionId:any):Observable<any>
  {
    console.log(sessionId);
    return this.http.get(`${this.url}/getLatestPayment?sessionId=${sessionId}`);
  }
  getAllPayments():Observable<any>
  {
    return this.http.get(this.url+"/getAllPayments");
  }
  getByid(id: any):Observable<any>
  {
    return this.http.get(`${this.url}/getById?id=${id}`);
  }
}
