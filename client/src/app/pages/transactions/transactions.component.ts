import { Component, OnInit } from '@angular/core';
import { FligthtTransactionsComponent } from "../../pages/Flights/fligtht-transactions/fligtht-transactions.component";
import { NavComponent } from '../../components/nav/nav.component';
import { AuthService } from '../../services/Account/auth.service';
import { TransactionTabsComponent } from "../../components/transaction-tabs/transaction-tabs.component";
import { FlightTicketComponent } from '../Flights/flight-ticket/flight-ticket.component';
import { HotelTransactionsComponent } from "../Hotels/hotel-transactions/hotel-transactions.component";
import { CarRentalTransactionsComponent } from "../CarRental/car-rental-transactions/car-rental-transactions.component";

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [NavComponent, FligthtTransactionsComponent, TransactionTabsComponent, FlightTicketComponent, HotelTransactionsComponent, CarRentalTransactionsComponent],
  templateUrl: './transactions.component.html',
  styleUrl: './transactions.component.scss'
})
export class TransactionsComponent implements OnInit {
  data:any=[];
  firstName='';
  constructor(private auth:AuthService){}
 ngOnInit(): void {
  this.auth.getUserName().subscribe((response)=>{
   this.data=response;
    console.log(this.data);
      this.firstName=this.data.firstName;
  }
    );
  
  }
}
