import { Component, OnInit } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterLink } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { faUser, faEnvelope, faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from '../../../services/Account/auth.service';
import { Router } from '@angular/router';
import { invalid } from 'moment';
import { CookieService } from 'ngx-cookie-service';
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

  constructor(private authservice: AuthService, private router: Router,private fb:FormBuilder,private cookieService:CookieService) {}
  ngOnInit(): void {
    this.registerForm=this.fb.group({
      firstName:['',Validators.required],
      lastName:[''],
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.minLength(8)]],
      confirmPassword:['',Validators.required]
    },{
      validatiors:this.checkPassword('password','confirmPassword')
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
    return this.registerForm.get('password');
  }
    get registerFormConfirmPassword()
  {
    return this.registerForm.get('confirmPassword');
  }
  checkPassword(password:string,confirmPassword:string):ValidatorFn
  {
    return (formGroup:AbstractControl):{ [ key:string ]: any }| null=>{
      console.log(formGroup.get(password));
      const passwordControl=formGroup.get(password);
      const confirmPasswordCOntrol=formGroup.get(confirmPassword);
      if(!passwordControl || !confirmPasswordCOntrol)
      {
        return null
      }
      if(confirmPasswordCOntrol.errors && !confirmPasswordCOntrol.errors['checkPassword'])
      {
        return null;
      }
      if(passwordControl.value !==confirmPasswordCOntrol.value)
      {
        confirmPasswordCOntrol.setErrors({ passwordMismatch:true });
        return { passwordMismach:true };
      }
        else{
        confirmPasswordCOntrol.setErrors(null);
        return null;   
        }
      }
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
    this.authservice.signup({
      firstName:this.registerForm.value.firstName,
      lastName:this.registerForm.value.lastName,
      email:this.registerForm.value.email,
      password:this.registerForm.value.password,

    }).subscribe({
      next: (response: any) => {
        localStorage.setItem('token', response.result.token);
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
