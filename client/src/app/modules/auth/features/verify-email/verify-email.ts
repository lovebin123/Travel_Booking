import { Component } from '@angular/core';
import { AuthService } from '../../../../services/auth-service';
import { Router } from '@angular/router';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';

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
        console.log(response);
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
