import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuardGuard } from './common/authGuard/auth-guard.guard';
import { adminGuard } from './common/authGuard/admin-guard.guard';
import { LandingPage } from './common/components/landing-page/landing-page';
import { PageNotFound } from './common/components/page-not-found/page-not-found';

const routes: Routes = [
  {path:'',component:LandingPage,pathMatch:'full'},
   {path:'auth', loadChildren: () => import('./modules/auth/auth-module').then(m => m.AuthModule)},
    {path:'dashboard',loadChildren:()=>import('./modules/user/user-module').then(m=>m.UserModule),},
    {path:'admin', loadChildren: ()=>import('./modules/admin/admin-module').then(m=>m.AdminModule),canActivate:[authGuardGuard,adminGuard]},
    {path:'**',component:PageNotFound},
    {path:'pageNotFound',component:PageNotFound}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
