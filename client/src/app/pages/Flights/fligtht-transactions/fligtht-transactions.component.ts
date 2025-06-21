import { Component } from '@angular/core';
import { FlightBookingTransactionComponent } from "./flight-booking-transaction/flight-booking-transaction.component";
import { FlightPaymentTransactionComponent } from "./flight-payment-transaction/flight-payment-transaction.component";

@Component({
  selector: 'app-fligtht-transactions',
  standalone: true,
  imports: [FlightBookingTransactionComponent, FlightPaymentTransactionComponent],
  templateUrl: './fligtht-transactions.component.html',
  styleUrl: './fligtht-transactions.component.scss'
})
export class FligthtTransactionsComponent {

}
