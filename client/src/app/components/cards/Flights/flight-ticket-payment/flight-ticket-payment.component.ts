import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-flight-ticket-payment',
  standalone: true,
  imports: [],
  templateUrl: './flight-ticket-payment.component.html',
  styleUrl: './flight-ticket-payment.component.scss'
})
export class FlightTicketPaymentComponent {
    @Input()paymentDetails:any;
  
  
}
