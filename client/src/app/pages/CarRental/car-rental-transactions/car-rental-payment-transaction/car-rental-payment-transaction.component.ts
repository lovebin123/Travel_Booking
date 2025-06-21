import { Component, OnInit } from '@angular/core';
import { CarRentalPayemntListComponent } from "../../../../components/cards/Car Rental/car-rental-payemnt-list/car-rental-payemnt-list.component";
import { CarRentalPaymentService } from '../../../../services/CarRental/CarRentalPayment/car-rental-payment.service';

@Component({
  selector: 'app-car-rental-payment-transaction',
  standalone: true,
  imports: [CarRentalPayemntListComponent],
  templateUrl: './car-rental-payment-transaction.component.html',
  styleUrl: './car-rental-payment-transaction.component.scss'
})
export class CarRentalPaymentTransactionComponent implements OnInit{
  constructor(private carRental:CarRentalPaymentService){}
ngOnInit(): void {
this.carRental.getAllPayments().subscribe({
  next:(response)=>{
    console.log(response);
    this.data=response;
  }
})
}
data:any={};
}
