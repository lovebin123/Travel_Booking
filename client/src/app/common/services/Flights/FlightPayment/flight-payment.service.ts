import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseFlightPaymentDto } from '../../../../../ap-api-client-angular';
import { environment } from '../../../../../environments/environment.development';
import { AutoWrapperResponse } from '../../../models/response';

@Injectable({
  providedIn: 'root'
})
export class FlightPaymentService {
  constructor(private http:HttpClient) { }
  private url=`${environment.apiUrl}/payments`;
  getLastPayement(sessionId:any):Observable<AutoWrapperResponse<ResponseFlightPaymentDto>>
  {
    return this.http.get<AutoWrapperResponse<ResponseFlightPaymentDto>>(`${this.url}/getLatestPayment?sessionId=${sessionId}`);
  }
  getAllPayments():Observable<any>
  {
    return this.http.get(this.url+"/getAllPayments");
  }
  getByid(id: any):Observable<AutoWrapperResponse<ResponseFlightPaymentDto>>
  {
    return this.http.get<AutoWrapperResponse<ResponseFlightPaymentDto>>(`${this.url}/getById?id=${id}`);
  }
}
