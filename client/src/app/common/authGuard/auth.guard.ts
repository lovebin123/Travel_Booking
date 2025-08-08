import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { AuthService } from '../../services/auth-service';

export const authGuardGuard: CanActivateFn = (route, state) => {
  const router=inject(Router);
  const authService=inject(AuthService);
  const token=localStorage.getItem('token');
  if(token!=null)
    return true;
  else{
    
    router.navigate(['/auth/login']);
  return true;
  }
};
  
