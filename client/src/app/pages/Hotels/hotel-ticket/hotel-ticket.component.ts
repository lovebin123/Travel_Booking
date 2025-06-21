import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HotelTicketDetailsComponent } from "../../../components/Ticket/Hotels/hotel-ticket-details/hotel-ticket-details.component";
import { HotelPaymentDetailsComponent } from "../../../components/Ticket/Hotels/hotel-payment-details/hotel-payment-details.component";
import { HotelServiceListComponent } from "../../../components/Ticket/Hotels/hotel-service-list/hotel-service-list.component";
import { HotelServicesComponent } from "../../../components/modals/hotels/hotel-services/hotel-services.component";
import jsPDF, { RGBAData } from 'jspdf';
import domtoimage from 'dom-to-image';
import { HotelPaymentService } from '../../../services/Hotels/HotelPayment/hotel-payment.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-hotel-ticket',
  standalone: true,
  imports: [HotelTicketDetailsComponent, HotelPaymentDetailsComponent, HotelServiceListComponent, HotelServicesComponent],
  templateUrl: './hotel-ticket.component.html',
  styleUrl: './hotel-ticket.component.scss'
})
export class HotelTicketComponent implements OnInit {
  id:any;
  constructor(private hotel:HotelPaymentService,private router:Router,private route:ActivatedRoute){
    const navigation=this.router.getCurrentNavigation();
    const state=navigation?.extras?.state as{id:any};
    if(state?.id)
    {
      this.id=state?.id;
    }
    else{
      const temp=localStorage.getItem('token');
      if(temp)
      {
        this.id=state?.id;
      }
    }
  }
    backHome()
  {
    this.router.navigate(['/transactions'],{state:{status:"Success"}});
  }
    data:any={};
  ngOnInit(): void {
    if(this.id===undefined)
    {
      const sessionID=this.route.snapshot.paramMap.get('sessionID');
    this.hotel.getLatest(sessionID).subscribe({
      next:(response)=>{
        console.log(response);
        this.data=response;
      }
    })
  }
  else{
    this.hotel.getById(this.id).subscribe({
      next:(response)=>{
        this.data=response;
      }
    })
  }
  }
      @ViewChild('ticketContent1', { static: false }) ticketContent!: ElementRef;
      @ViewChild('ticketButton1', { static: false }) ticketButton!: ElementRef;
downloadPdf() {
  const node = this.ticketContent.nativeElement;
  const button = this.ticketButton.nativeElement;
  const originalDisplay = button.style.display;
  button.style.display = 'none';
  domtoimage.toPng(node, { bgcolor: '#fff' }).then((dataUrl: string) => {
    const img = new Image();
    img.src = dataUrl;
    img.onload = () => {
      const pdfWidth = img.width;
      const pdfHeight = img.height;
      const orientation = pdfWidth > pdfHeight ? 'l' : 'p';
      const doc = new jsPDF(orientation, 'px', [pdfWidth, pdfHeight]);
      const width = doc.internal.pageSize.getWidth();
      const height = doc.internal.pageSize.getHeight();
      doc.addImage(dataUrl, 'PNG', 0, 0, pdfWidth, pdfHeight);
      doc.save(`Hotel_ticket_${this.data.stripe_payement_intent_id}.pdf`);
      button.style.display = originalDisplay;
    };
  }).catch((error) => {
    console.error("Error generating PDF", error);
    button.style.display = originalDisplay;
  });
}
}
