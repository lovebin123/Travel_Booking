import { Component, OnInit } from '@angular/core';
import { NavComponent } from "../../components/nav/nav.component";
import { AuthService } from '../../services/Account/auth.service';
import { UserDetails } from '../../models/userDetails';
import { response } from 'express';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [NavComponent,CommonModule,FormsModule,NgbToastModule],
  templateUrl: './edit-profile.component.html',
  styleUrl: './edit-profile.component.scss'
})
export class EditProfileComponent implements OnInit{
 data:any=[];
 userData:any={};
  firstName='';
  data1:UserDetails={
    email:'',
    firstName:'',
    lastName:'',
    phoneNumber:''
  };
  constructor(private auth:AuthService){}
 ngOnInit(): void {
  this.auth.getUserName().subscribe((response:any)=>{
   this.data=response.result;
      this.firstName=this.data.firstName;
  }
)
 this.loadData();
}
loadData()
{
   this.auth.getAllUserDetails().subscribe({
    next:(response)=>{
      console.log(response);
      this.userData=response.result;
      this.data1.email=this.userData.email;
      this.data1.firstName=this.userData.firstName;
      this.data1.lastName=this.userData.lastName;
      this.data1.phoneNumber=this.userData.phoneNumber;
    }
  })
}
showToast=false;
save()
{
  this.auth.updateUserDetails(this.data1).subscribe({
    next:(response)=>{
      this.showToast=true;
      this.loadData();
    }
  })
}
}
