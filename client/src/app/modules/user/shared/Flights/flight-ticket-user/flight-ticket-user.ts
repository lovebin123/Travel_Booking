import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-ticket-user',
  standalone: false,
  templateUrl: './flight-ticket-user.html',
  styleUrl: './flight-ticket-user.css'
})
export class FlightTicketUser {
  @Input() userDetails:any;

}
