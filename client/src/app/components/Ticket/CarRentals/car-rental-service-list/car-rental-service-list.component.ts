import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-car-rental-service-list',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-service-list.component.html',
  styleUrl: './car-rental-service-list.component.scss'
})
export class CarRentalServiceListComponent {
@Input()data:any={};
}
