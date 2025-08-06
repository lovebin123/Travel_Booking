import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-services',
  standalone: false,
  templateUrl: './car-rental-services.html',
  styleUrl: './car-rental-services.css'
})
export class CarRentalServices {
@Input()data:any=null;

}
