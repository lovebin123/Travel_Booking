import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-hotel-services',
  standalone: true,
  imports: [],
  templateUrl: './hotel-services.component.html',
  styleUrl: './hotel-services.component.scss'
})
export class HotelServicesComponent {
@Input()hotelData:any;
@Input()adults:any;
@Input()children:any;
@Input()data:any={};

}
