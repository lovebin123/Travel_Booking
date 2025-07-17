import { Component, OnInit } from '@angular/core';
import { CarRentalListComponent } from "../../../../components/cards/Car Rental/car-rental-list/car-rental-list.component";
import { CarRentalBookingService } from '../../../../services/CarRental/CarRentalBooking/car-rental-booking.service';
import { CarRentalPaymentService } from '../../../../services/CarRental/CarRentalPayment/car-rental-payment.service';

@Component({
  selector: 'app-car-rental-booking-transaction',
  standalone: true,
  imports: [CarRentalListComponent],
  templateUrl: './car-rental-booking-transaction.component.html',
  styleUrl: './car-rental-booking-transaction.component.scss'
})
export class CarRentalBookingTransactionComponent implements OnInit {
constructor(private carRental1:CarRentalBookingService,private carRental2:CarRentalPaymentService){
  
}
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
