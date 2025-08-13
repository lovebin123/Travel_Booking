import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-user',
  standalone: false,
  templateUrl: './car-rental-user.html',
  styleUrl: './car-rental-user.css'
})
export class CarRentalUser {
  @Input() data: any = null;

}
