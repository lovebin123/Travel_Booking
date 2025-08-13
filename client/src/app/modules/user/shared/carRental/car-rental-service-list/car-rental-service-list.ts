import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-service-list',
  standalone: false,
  templateUrl: './car-rental-service-list.html',
  styleUrl: './car-rental-service-list.css'
})
export class CarRentalServiceList {
  @Input() data: any = {};

}
