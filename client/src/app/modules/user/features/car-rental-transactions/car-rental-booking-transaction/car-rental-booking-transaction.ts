import { Component, OnInit } from '@angular/core';
import { CarRentalBookingService } from '../../../../../services/CarRental/CarRentalBooking/car-rental-booking.service';
import { CarRentalPaymentService } from '../../../../../services/CarRental/CarRentalPayment/car-rental-payment.service';

@Component({
  selector: 'app-car-rental-booking-transaction',
  standalone: false,
  templateUrl: './car-rental-booking-transaction.html',
  styleUrl: './car-rental-booking-transaction.css'
})
export class CarRentalBookingTransaction implements OnInit {
constructor(private carRental1:CarRentalBookingService){}
data:any={};
data2:any={};
  ngOnInit(): void {
    this.loadData();
  }
  loadData()
  {
     this.carRental1.getUserBooking().subscribe({
    next:(response:any)=>{
      this.data=response.result;
      console.log(this.data);
    }
   })
  }
}
