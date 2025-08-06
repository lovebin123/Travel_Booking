import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../services/auth-service';

@Component({
  selector: 'app-admin-dashboard',
  standalone: false,
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css'
})
export class AdminDashboard implements OnInit {
  constructor(private auth:AuthService){}
  ngOnInit(): void {
    this.firstName=this.auth.getUserName().subscribe({
      next:(response:any)=>{
        this.firstName=response.result.firstName;
      }
    })
  }
firstName: any;

}
