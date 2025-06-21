import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import {JwtHelperService} from "@auth0/angular-jwt"
import { timeout } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url="http://localhost:5253/api/account";
  private jwtHelper=new JwtHelperService();
  constructor(private http:HttpClient,private router:Router) { }
  signup(userData:any)
  {
    return this.http.post(this.url+'/signup',userData);
  }
  login(userData: any) {
    return this.http.post(this.url + '/login', userData);
  }
  verifyEmail(userData:any)
  {
    return this.http.post(this.url+'/verifyEmail',userData);
  }
  forgotPassword(userData:any)
  {
    return this.http.post(this.url+'/forgotPassword',userData);
  }
  saveToken(token:string)
  {
    if(typeof window!="undefined")
    {
      localStorage.setItem('token',token);
    }
  }
  findEmail(token:any)
  {
    const decodedTOken=this.jwtHelper.decodeToken(token);
    return decodedTOken?.email;
  }
  getToken():string|null
  {
    if(typeof window!=undefined)
    return localStorage.getItem('token')??null;
  return null;
  }
  getEmail()
  {
    const token=this.getToken();
    if(token)
    {
      const decodedToken=this.jwtHelper.decodeToken(token);
      return decodedToken?.email;
    }
    else
    return null;
  }
 
getUserName() {
  const token = localStorage.getItem('token');
  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`,
  });
  const email = this.getEmail();
  return this.http.get(this.url + `/getUserName?email=${email}`, { headers });
}
  logout()
  {
    if(typeof window!="undefined")
      localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
  isAuthenticated():boolean
  {
    const token=localStorage.getItem('token');
    return token ? this.jwtHelper.isTokenExpired(token) :false;
  }
}
