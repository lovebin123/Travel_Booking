import { Component, OnInit } from '@angular/core';
import {faUser,faEnvelope,faLock} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../services/Account/auth.service';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [FontAwesomeModule,RouterLink,CommonModule,FormsModule,NgbToastModule],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss'
})
export class ForgotPasswordComponent implements OnInit {
  userData={email:'',password:''};
  cpassword='';
  token:any;
  showToast=false;
  passwordMismatch=false;
  constructor(private route:ActivatedRoute,private auth:AuthService,private router:Router){
  }
  ngOnInit(): void {
    const token=this.route.snapshot.paramMap.get('sessionID');
    this.userData.email=this.auth.findEmail(token);
  }
  checkPassword()
  {
    if(this.userData.password!=this.cpassword)
    {
      this.passwordMismatch=true;
      return;
    }
    this.passwordMismatch=false;
  }   
  forgotPassword(){
    this.auth.forgotPassword(this.userData).subscribe({
      next:(response:any)=>{
        this.checkPassword();
        console.log(response);
        console.log("Password reset successfully");
        localStorage.setItem('token',response.result.token);
        this.showToast=true;
        this.userData.email='';
        this.userData.password='';
        this.cpassword='';
      },
      error:()=>{
        console.log("Error");
      }
    })
  }

faEnvelope=faEnvelope;
faKey=faLock;
faUser=faUser;
}
