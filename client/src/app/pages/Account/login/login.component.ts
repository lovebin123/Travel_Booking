import { Component, ElementRef, ViewChild } from '@angular/core';
import {faUser,faEnvelope,faLock} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {CommonModule} from "@angular/common";
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../../services/Account/auth.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FontAwesomeModule,RouterLink,FormsModule,CommonModule,NgbToastModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
faUser=faUser;
faEnvelope=faEnvelope;
faKey=faLock;
userData={email:'',password:''};
showToast=false;
constructor(private auth:AuthService,private router:Router){}
@ViewChild('showPassword',{static:false}) showPassword!:ElementRef;
@ViewChild('password',{static:false})password!:ElementRef;
login() {
  this.auth.login({
    email:this.userData.email,
    password:this.userData.password
  }).subscribe({
    next: (response: any) => {
      localStorage.setItem('token', response.token);
      localStorage.setItem('role',response.role);
      if(this.userData.email==='admin@gmail.com')
          this.router.navigate(['/admin'])
      else
          this.router.navigate(['/hero']);
    },
    error: () => {
      this.showToast=true;
      console.log("Error");
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