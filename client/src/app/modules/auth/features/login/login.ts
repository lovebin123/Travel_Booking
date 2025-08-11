import { ChangeDetectorRef, Component, DoCheck, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {faUser,faEnvelope,faLock, faEye, faEyeSlash} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, Validators,ReactiveFormsModule } from '@angular/forms';
import {CommonModule} from "@angular/common";
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { tick } from '@angular/core/testing';
import { AuthService } from '../../../../common/services/auth-service';
@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login{
     registerForm!:FormGroup;
  submitted=false;
  faUser=faUser;
faEnvelope=faEnvelope;
showPassword1=false;
faKey=faLock;
showToast=false;
errorMessage='';
currentType='';
  faEye = faEye;
  faEyeSlash = faEyeSlash;
constructor(private auth:AuthService,private router:Router,private fb:FormBuilder){
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
  this.auth.login({
    email:this.registerForm.value.email,
    password:this.registerForm.value.password
  }).subscribe({
    next: (response: any) => {
      
      localStorage.setItem('token', response.token);
      localStorage.setItem('role',response.role);
      localStorage.setItem("refreshToken",response.refreshToken)
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
      console.log(err)
    }
  });
}
show()
{
    this.showPassword1 = !this.showPassword1;
  const input=this.password.nativeElement;
this.currentType=input.getAttribute('type');
  if(this.currentType==='password')
  {
    input.setAttribute('type','text');
  }
  else if(this.currentType==='text')
  {
    input.setAttribute('type','password');
  }
  
}
get passwordIcon() {
    return this.showPassword1 ? this.faEyeSlash : this.faEye;
  }

}
