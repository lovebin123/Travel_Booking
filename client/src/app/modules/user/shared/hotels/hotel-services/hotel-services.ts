import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-hotel-services',
  standalone: false,
  templateUrl: './hotel-services.html',
  styleUrl: './hotel-services.css'
})
export class HotelServices {
@Input()hotelData:any;
@Input()adults:any;
@Input()children:any;
@Input()data:any={};
}
