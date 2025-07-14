import { Component } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { faUser, faEnvelope, faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from '../../../services/Account/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink, NgbToastModule,FontAwesomeModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {
  userData = { firstName: '', lastName: '', email: '', password: '' };
  cpassword = '';
  accepted_terms = false;
  error_message = '';
  passwordMismach = false;
  showToast = false;
  faEnvelope = faEnvelope;
  faKey = faLock;
  faUser = faUser;

  constructor(private authservice: AuthService, private router: Router) {}
  checkPassword()
  {
    if(this.userData.password==this.cpassword)
    {
      this.passwordMismach=true;
      return;
    }
    this.passwordMismach=false;
  }
  handleChange()
  {
   if(this.accepted_terms==false)
    this.accepted_terms=true;
   else
   this.accepted_terms=false;
  }
  showToast1=false;
  signup() {
    if(this.accepted_terms==false)
    {
    this.showToast1=true;
    return;
    }
    this.authservice.signup(this.userData).subscribe({
      next: (response: any) => {
        this.checkPassword();
        localStorage.setItem('token', response.token);
        this.router.navigate(['/login']);
      },
      error: () => {
        this.error_message = 'Please fill all details';
        this.showToast = true;
        console.log("Error");
      }
    });
  }

  closeToast() {
    this.showToast = false;
  }
}
