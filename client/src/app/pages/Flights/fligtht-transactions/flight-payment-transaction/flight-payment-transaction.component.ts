import { FlightPaymentService } from './../../../../services/Flights/FlightPayment/flight-payment.service';
import { Component, OnInit } from '@angular/core';
import { FlightPaymentListComponent } from "../../../../components/cards/Flights/flight-payment-list/flight-payment-list.component";

@Component({
  selector: 'app-flight-payment-transaction',
  standalone: true,
  imports: [FlightPaymentListComponent],
  templateUrl: './flight-payment-transaction.component.html',
  styleUrl: './flight-payment-transaction.component.scss'
})
export class FlightPaymentTransactionComponent implements OnInit {
  constructor(private flight:FlightPaymentService){}
  data:any=null;
  ngOnInit(): void {
    this.flight.getAllPayments().subscribe((response:any)=>{
      this.data=response;
      console.log(response);
    })
  }
  
}
