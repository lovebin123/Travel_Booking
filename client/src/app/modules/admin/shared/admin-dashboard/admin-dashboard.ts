import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../common/services/auth-service';
import { LocationStrategy } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  standalone: false,
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css'
})
export class AdminDashboard implements OnInit {
  constructor(private auth:AuthService,private location:LocationStrategy,private router:Router){
    const nav=router.getCurrentNavigation();
const state=nav?.extras.state as {loginSuccessful:boolean};
this.loginSuccessful=state?.loginSuccessful;
history.replaceState({}, '');
  }
  stateListener:any;
  loginSuccessful=false;
  ngOnInit(): void {
    this.firstName=this.auth.getUserName().subscribe({
      next:(response:any)=>{
        this.firstName=response.result.firstName;
      }
    })
    this.stateListener=this.location.onPopState(()=>{
      this.auth.logout();
    })
  }
firstName: any;

}
