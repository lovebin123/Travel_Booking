import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './features/login/login';
import { SignUp } from './features/sign-up/sign-up';
import { VerifyEmail } from './features/verify-email/verify-email';
import { AuthLayout } from './shared/auth-layout/auth-layout';
import { ForgotPassword } from './features/forgot-password/forgot-password';

const routes: Routes = [
  {
    path:'',component:AuthLayout,
    children:[
  {path: 'login', component:Login},
  {path: 'signup', component: SignUp} ,
  {path:'verifyEmail',component:VerifyEmail},
  {path:'forgotPassword/:sessionID',component:ForgotPassword}
    ]  
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
