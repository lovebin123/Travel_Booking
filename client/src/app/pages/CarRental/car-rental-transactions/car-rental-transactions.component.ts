import { Component } from '@angular/core';
import { CarRentalBookingTransactionComponent } from "./car-rental-booking-transaction/car-rental-booking-transaction.component";
import { CarRentalPaymentTransactionComponent } from "./car-rental-payment-transaction/car-rental-payment-transaction.component";

@Component({
  selector: 'app-car-rental-transactions',
  standalone: true,
  imports: [CarRentalBookingTransactionComponent, CarRentalPaymentTransactionComponent],
  templateUrl: './car-rental-transactions.component.html',
  styleUrl: './car-rental-transactions.component.scss'
})
export class CarRentalTransactionsComponent {

}
