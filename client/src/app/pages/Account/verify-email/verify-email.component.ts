import { AuthService } from './../../../services/Account/auth.service';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { FormsModule } from '@angular/forms';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-verify-email',
  standalone: true,
  imports: [CommonModule,RouterLink,FontAwesomeModule,FormsModule,NgbToastModule],
  templateUrl: './verify-email.component.html',
  styleUrl: './verify-email.component.scss'
})
export class VerifyEmailComponent {
  constructor(private auth:AuthService,private router:Router){}
  faEnvelope=faEnvelope;
 userData={email:''};
 showToast=false;
 showToast1=false;
  verify_mail()
  {
    this.auth.verifyEmail(this.userData).subscribe(
    {
      next:(response:any)=>{
        
        localStorage.setItem('token',response.result.token);
        this.showToast1=true;
      },
      error:()=>{
        this.showToast=true;
      }
    }
    )
  }
}
