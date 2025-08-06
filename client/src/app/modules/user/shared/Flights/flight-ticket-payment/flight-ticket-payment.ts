import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-ticket-payment',
  standalone: false,
  templateUrl: './flight-ticket-payment.html',
  styleUrl: './flight-ticket-payment.css'
})
export class FlightTicketPayment {
    @Input()paymentDetails:any;

}
