import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.html',
  styleUrl: './landing-page.css',
  standalone:true,
  imports:[]
})
export class LandingPage {
constructor(private router:Router){}
navToLogin()
{
  this.router.navigate(['/auth/login']);
}
}
