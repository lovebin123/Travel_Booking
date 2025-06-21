import { Component, Input, OnInit } from '@angular/core';
import { HotelDetailsComponent } from "../../../components/modals/hotels/hotel-details/hotel-details.component";
import { HotelCheckinComponent } from "../../../components/searchComponent/Hotels/hotel-checkin/hotel-checkin.component";
import { HotelCheckinCheckoutComponent } from "../../../components/modals/hotels/hotel-checkin-checkout/hotel-checkin-checkout.component";
import { HotelServicesComponent } from "../../../components/modals/hotels/hotel-services/hotel-services.component";
import { HotelUserComponent } from "../../../components/modals/hotels/hotel-user/hotel-user.component";
import { DateTimeService } from '../../../services/DateTime/date-time.service';
import { HotelBookingServiceService } from '../../../services/Hotels/HotelBooking/hotel-booking-service.service';

@Component({
  selector: 'app-hotel-booking-modal',
  standalone: true,
  imports: [HotelDetailsComponent, HotelCheckinComponent, HotelCheckinCheckoutComponent, HotelServicesComponent, HotelUserComponent],
  templateUrl: './hotel-booking-modal.component.html',
  styleUrl: './hotel-booking-modal.component.scss',
   providers:[{
          provide:DateTimeService,
          useFactory:()=>new DateTimeService()
        }],
})
export class HotelBookingModalComponent  {
  constructor(private hotel:HotelBookingServiceService){}
@Input()data:any={};
pay(id:any)
{
  this.hotel.createSession(id).subscribe({
    next:(response:any)=>{
      document.location.href=response.url;
    }
  })
}

}
