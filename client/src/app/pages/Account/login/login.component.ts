import { ChangeDetectorRef, Component, DoCheck, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {faUser,faEnvelope,faLock} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, Validators,ReactiveFormsModule } from '@angular/forms';
import {CommonModule} from "@angular/common";
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../../services/Account/auth.service';
import { tick } from '@angular/core/testing';
import {CookieService} from "ngx-cookie-service"
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FontAwesomeModule,RouterLink,FormsModule,CommonModule,NgbToastModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnDestroy,OnInit {
  registerForm!:FormGroup;
  submitted=false;
  faUser=faUser;
faEnvelope=faEnvelope;
faKey=faLock;
showToast=false;
errorMessage='';
constructor(private auth:AuthService,private router:Router,private fb:FormBuilder,private cookieService:CookieService){
}
  ngOnInit(): void {
    this.registerForm=this.fb.group({
      email:['',[Validators.required,Validators.email]],
      password:['',Validators.required]
    })
  }
  ngOnDestroy(): void {
    this.registerForm.value.email='';
    this.registerForm.value.password='';
  }
@ViewChild('showPassword',{static:false}) showPassword!:ElementRef;
@ViewChild('password',{static:false})password!:ElementRef;
get registerFormControlEmail()
{
  return this.registerForm.get('email');
}
get registerFormControlPassword()
{
  return this.registerForm.get('password');
}
login() {
  this.submitted=true;
  console.log(this.registerForm.value);
  this.auth.login({
    email:this.registerForm.value.email,
    password:this.registerForm.value.password
  }).subscribe({
    next: (response: any) => {
      console.log(response);
      
      localStorage.setItem('token', response.result.token);
      localStorage.setItem('role',response.result.role);
      localStorage.setItem("refreshToken",response.result.refreshToken)
      if(this.registerForm.value.email==='admin@gmail.com')
      {
        this.ngOnDestroy();
          this.router.navigate(['/admin'])
      }
      else
          this.router.navigate(['/dashboard']);
    },
    error: (err:any) => {
      this.showToast=true;
      this.errorMessage=err.error.responseException.exceptionMessage;
      console.log(this.errorMessage)
    }
  });
}
show()
{
  const input=this.password.nativeElement;
  const btn=this.showPassword.nativeElement;
  const currentType=input.getAttribute('type');
  if(currentType==='password')
    input.setAttribute('type','text');
  else if(currentType==='text')
    input.setAttribute('type','password');
  if(btn.classList.contains('fa-eye-slash'))
  {
    btn.classList.remove('fa-eye-slash');
    btn.classList.add('fa-eye');
  }
  else if(btn.classList.contains('fa-eye'))
  {
    btn.classList.remove('fa-eye');
    btn.classList.add('fa-eye-slash');
  }
}
}