import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-user',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-user.component.html',
  styleUrl: './car-rental-user.component.scss'
})
export class CarRentalUserComponent {
@Input()data:any=null;
}
