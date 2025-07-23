import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { AuthService } from '../Account/auth.service';

export const errorInterceptorInterceptor: HttpInterceptorFn = (req, next) => {
 const auth=inject(AuthService);
  return next(req).pipe(
    catchError((error:HttpErrorResponse)=>{
      if(error.status===401)
      {
        const isContinue=confirm("Are you sure you want to continue");
        if(isContinue)
          auth.tokenExpired$.next(true);
      }
              return throwError(error);

    })
  );
};
