import { Component } from '@angular/core';
import { HotelBookingTransactionComponent } from "./hotel-booking-transaction/hotel-booking-transaction.component";
import { HotelPaymentTransactionComponent } from "./hotel-payment-transaction/hotel-payment-transaction.component";

@Component({
  selector: 'app-hotel-transactions',
  standalone: true,
  imports: [HotelBookingTransactionComponent, HotelPaymentTransactionComponent],
  templateUrl: './hotel-transactions.component.html',
  styleUrl: './hotel-transactions.component.scss'
})
export class HotelTransactionsComponent {

}
