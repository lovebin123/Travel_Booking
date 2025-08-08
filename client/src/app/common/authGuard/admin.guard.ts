import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const adminGuard: CanActivateFn = (route, state) => {
  const router=inject(Router);
  const role=localStorage.getItem('role');
  console.log(role);
  if(role==='Admin')
  {
    return true;
  }
  else{
    router.navigate(['/pageNotFound']);
    return false;
  }
};
