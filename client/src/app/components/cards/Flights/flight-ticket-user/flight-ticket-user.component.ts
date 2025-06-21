import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-ticket-user',
  standalone: true,
  imports: [],
  templateUrl: './flight-ticket-user.component.html',
  styleUrl: './flight-ticket-user.component.scss'
})
export class FlightTicketUserComponent {
  @Input() userDetails:any;

}
