import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth-service';

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
  
