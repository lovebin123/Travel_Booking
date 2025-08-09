import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../common/services/auth-service';

@Component({
  selector: 'app-transactions',
  standalone: false,
  templateUrl: './transactions-layout.html',
  styleUrl: './transactions-layout.css'
})
export class TransactionsLayout implements OnInit {
 data:any=[];
  firstName='';
  constructor(private auth:AuthService){}
 ngOnInit(): void {
  this.auth.getUserName().subscribe((response:any)=>{
    response=response.result;
   this.data=response;
    console.log(this.data);
      this.firstName=this.data.firstName;
  }
    );
  
  }
}
