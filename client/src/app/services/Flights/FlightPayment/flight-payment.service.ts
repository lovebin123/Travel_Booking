import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class FlightPaymentService {
  constructor(private http:HttpClient) { }
  private url=`${environment.apiUrl}/payments`;
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
