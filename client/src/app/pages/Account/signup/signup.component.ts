import { Component, OnInit } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { faUser, faEnvelope, faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from '../../../services/Account/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink, NgbToastModule,FontAwesomeModule,ReactiveFormsModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent implements OnInit{
  registerForm!:FormGroup;
  userData = { firstName: '', lastName: '', email: '', password: '' };
  cpassword = '';
  accepted_terms = false;
  error_message = '';
  passwordMismach = false;
  showToast = false;
  submitted=false;
  faEnvelope = faEnvelope;
  faKey = faLock;
  faUser = faUser;

  constructor(private authservice: AuthService, private router: Router,private fb:FormBuilder) {}
  ngOnInit(): void {
    this.registerForm=this.fb.group({
      firstName:['',Validators.required],
      lastName:[''],
      email:['',[Validators.required,Validators.email]],
      password:['',Validators.required],
      confirmPassword:['',Validators.required]
    })

  }
  get registerFormFirstName(){
    return this.registerForm.get('firstName');
  }
  get registerFormlastName()
  {
    return this.registerForm.get('lastName');
  }
  get registerFormEmail()
  {
    return this.registerForm.get('email');
  }
  get registerFormPassword()
  {
    return this.registerForm.get('password')
  }
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
