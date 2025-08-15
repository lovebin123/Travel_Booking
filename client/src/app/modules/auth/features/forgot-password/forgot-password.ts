import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { faEnvelope, faUser } from '@fortawesome/free-solid-svg-icons';
import { faLock } from '@fortawesome/free-solid-svg-icons/faLock';
import { AuthService } from '../../../../common/services/auth-service';
import { NewUserDto } from '../../../../../ap-api-client-angular';

@Component({
  selector: 'app-forgot-password',
  standalone: false,
  templateUrl: './forgot-password.html',
  styleUrl: './forgot-password.css'
})
export class ForgotPassword {
  userData = { email: '', password: '', verificationCode: '' };
  cpassword = '';
  token: any;
  showToast = false;
  passwordMismatch = false;
  changeSuccessful = false;
  constructor(private route: ActivatedRoute, private auth: AuthService, private router: Router) {
  }
  ngOnInit(): void {
    const token = this.route.snapshot.paramMap.get('sessionID');
    this.userData.email = this.auth.findEmail(token);
  }
  checkPassword() {
    NewUserDto
    if (this.userData.password != this.cpassword) {
      this.passwordMismatch = true;
      return;
    }
    this.passwordMismatch = false;
  }
  forgotPassword() {
    this.auth.forgotPassword({ email: this.userData.email, password: this.userData.password, verificationCode: this.userData.verificationCode }).subscribe({
      next: (response: any) => {
        localStorage.setItem('token', response.result.token);
        this.showToast = true;
        this.userData.email = '';
        this.userData.password = '';
        this.cpassword = '';
        this.changeSuccessful = true;
        this.router.navigate(['/auth/login'], { state: { changeSuccessful: this.changeSuccessful } });
      },
      error: () => {
        console.log("Error");
      }
    })
  }

  faEnvelope = faEnvelope;
  faKey = faLock;
  faUser = faUser;
}
