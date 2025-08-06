import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing-module';
import { Login } from './features/login/login';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import InputFieldComponent from '../../common/components/input-field/input-field';
import InputField from '../../common/components/input-field/input-field';
import { Button } from '../../common/components/button/button';
import { SignUp } from './features/sign-up/sign-up';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VerifyEmail } from './features/verify-email/verify-email';
import { AuthLayout } from './shared/auth-layout/auth-layout';
import { RouterOutlet } from '@angular/router';
import { ForgotPassword } from './features/forgot-password/forgot-password';


@NgModule({
  declarations: [
    Login,
    SignUp,
    VerifyEmail,
    AuthLayout,
    ForgotPassword,
  ],
  imports: [
    CommonModule,  AuthRoutingModule,ReactiveFormsModule,FormsModule,
    InputField,
    Button,
    NgbToastModule,
    FontAwesomeModule,
    RouterOutlet
  ]
})
export class AuthModule { }
