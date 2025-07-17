import { Component, OnInit } from '@angular/core';
import { HotelPaymentListComponent } from "../../../../components/cards/Hotels/hotel-payment-list/hotel-payment-list.component";
import { HotelPaymentService } from '../../../../services/Hotels/HotelPayment/hotel-payment.service';

@Component({
  selector: 'app-hotel-payment-transaction',
  standalone: true,
  imports: [HotelPaymentListComponent],
  templateUrl: './hotel-payment-transaction.component.html',
  styleUrl: './hotel-payment-transaction.component.scss'
})
export class HotelPaymentTransactionComponent implements OnInit {
data:any={};
constructor(private hotel:HotelPaymentService){}
  ngOnInit(): void {
    this.hotel.getAllPayments().subscribe({
      next:(response)=>{
        response=response.result;
        this.data=response;
      }
    })
  }
}
