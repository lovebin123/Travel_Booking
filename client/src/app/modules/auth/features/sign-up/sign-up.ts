import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl,FormBuilder, FormGroup, ReactiveFormsModule, Validators,ValidatorFn } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { faUser, faEnvelope, faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from '../../../../services/auth-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  standalone: false,
  templateUrl: './sign-up.html',
  styleUrls: ['./sign-up.css']
})
export class SignUp implements OnInit{
  registerForm!:FormGroup;
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
        localStorage.setItem('token', response.token);
        this.router.navigate(['/auth/login']);
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