import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuardGuard } from './common/authGuard/auth.guard';
import { adminGuard } from './common/authGuard/admin.guard';
import { LandingPage } from './common/components/landing-page/landing-page';
import { PageNotFound } from './common/components/page-not-found/page-not-found';
import { EditProfileComponent } from './common/components/edit-profile/edit-profile.component';
import { PaymentFailureComponent } from './common/components/payment-failure/payment-failure.component';
import { userGuardGuard } from './common/authGuard/user.guard';

const routes: Routes = [
  {path:'',component:LandingPage,pathMatch:'full'},
   {path:'auth', loadChildren: () => import('./modules/auth/auth-module').then(m => m.AuthModule)},
    {path:'dashboard',loadChildren:()=>import('./modules/user/user-module').then(m=>m.UserModule),canActivate:[authGuardGuard,userGuardGuard]},
    {path:'admin', loadChildren: ()=>import('./modules/admin/admin-module').then(m=>m.AdminModule),canActivate:[authGuardGuard,adminGuard]},
    {path:'editProfile',component:EditProfileComponent},
    {path:'pageNotFound',component:PageNotFound},
    {path:'paymentFailure',component:PaymentFailureComponent},
        {path:'**',component:PageNotFound},

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
