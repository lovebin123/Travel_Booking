import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faUser, faUserCircle, faSuitcase } from '@fortawesome/free-solid-svg-icons';
import { LocationStrategy } from '@angular/common';
import { AuthService } from '../../../../common/services/auth-service';

@Component({
  selector: 'app-user-layout',
  standalone: false,
  templateUrl: './user-layout.html',
  styleUrl: './user-layout.css'
})
export class UserLayout implements OnInit {
faUser=faUser;
  faUserCircle=faUserCircle;
  faSuitcase=faSuitcase;
  firstName:any='';
  data:any=[];
  private stateListener:any;
  constructor(private router:Router,private auth:AuthService,private location:LocationStrategy){
    const nav=this.router.getCurrentNavigation();
    const state=nav?.extras.state as({loginSuccessful:boolean});
    this.loginSuccessful=state?.loginSuccessful;
    history.replaceState({},'');
  }
  loginSuccessful=false;
  ngOnInit(): void {
  this.auth.getUserName().subscribe((response:any)=>{
   this.data=response.result;
      this.firstName=this.data.firstName;
  }
    );
      this.stateListener=this.location.onPopState(()=>{
    this.auth.logout();
  })

  }
  logout()
  {
    this.auth.logout();
  }

}

