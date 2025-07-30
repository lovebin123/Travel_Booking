import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';

export const authGuardGuard: CanActivateFn = (route, state): Observable<boolean> => {
  const jwtHelper = inject(JwtHelperService);
  const router = inject(Router);
  const http = inject(HttpClient);
  
  const token = localStorage.getItem('token');

  if (token && !jwtHelper.isTokenExpired(token)) {
    console.log(jwtHelper.decodeToken(token));
    return of(true);
  }

  return tryRefreshingTokens(http).pipe(
    tap((success) => {
      if (!success) {
        router.navigate(['/login']);
      }
    })
  );
};

function tryRefreshingTokens(http: HttpClient): Observable<boolean> {
  const token = localStorage.getItem('token');
  const refreshToken = localStorage.getItem('refreshToken');
console.log(refreshToken);
  if (!token || !refreshToken) {
    return of(false);
  }

  const credentials = {
    accessToken: token,
    refreshToken: refreshToken
  };

  return http.post<any>("http://localhost:5253/api/account/refresh", credentials).pipe(
    map((res: any) => {
      if (res) {
        localStorage.setItem('token', res.result.token);
        localStorage.setItem('refreshToken', res.result.refreshToken);
        return true;
      }
      return false;
    }),
    catchError((error) => {
      console.error('Refresh token error:', error);
      return of(false);
    })
  );
}