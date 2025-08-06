import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faUser, faUserCircle, faSuitcase } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from '../../../../services/auth-service';

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
  constructor(private router:Router,private auth:AuthService){
  }
  ngOnInit(): void {
  this.auth.getUserName().subscribe((response:any)=>{
    console.log(response);
   this.data=response.result;
      this.firstName=this.data.firstName;
  }
    );
  
  }
  logout()
  {
    this.auth.logout();
  }

}

