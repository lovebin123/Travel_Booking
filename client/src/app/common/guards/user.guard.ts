import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const userGuardGuard: CanActivateFn = (route, state) => {
  const router=inject(Router);
  const role=localStorage.getItem('role');
  if(role==='User')
  {
    return true;
  }
  else{
    router.navigate(['/pageNotFound']);
    return false;
  }
};
