import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from '../../../../common/services/auth-service';

@Component({
  selector: 'app-verify-email',
  standalone: false,
  templateUrl: './verify-email.html',
  styleUrl: './verify-email.css'
})
export class VerifyEmail {
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
