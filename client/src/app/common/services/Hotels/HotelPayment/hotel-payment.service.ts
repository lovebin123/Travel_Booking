import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class HotelPaymentService {
  constructor(private http:HttpClient) {}
  private url=`${environment.apiUrl}/hotelPayement`
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
