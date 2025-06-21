import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-services',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-services.component.html',
  styleUrl: './car-rental-services.component.scss'
})
export class CarRentalServicesComponent {
@Input()data:any=null;

}
