import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import jsPDF from 'jspdf';
import domtoimage from 'dom-to-image';
import { HotelPaymentService } from '../../../../services/Hotels/HotelPayment/hotel-payment.service';
@Component({
  selector: 'app-hotel-ticket',
  standalone: false,
  templateUrl: './hotel-ticket.html',
  styleUrl: './hotel-ticket.css'
})
export class HotelTicket implements OnInit {
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
    this.router.navigate(['/dashboard/transactions'],{state:{status:"Success"}});
  }
    data:any={};
  ngOnInit(): void {
    if(this.id===undefined)
    {
      const sessionID=this.route.snapshot.paramMap.get('sessionID');
    this.hotel.getLatest(sessionID).subscribe({
      next:(response:any)=>{
        response=response.result;
        console.log(response);
        this.data=response;
      }
    })
  }
  else{
    this.hotel.getById(this.id).subscribe({
      next:(response)=>{
        response=response.result;
        this.data=response;
      }
    })
  }
  }
      @ViewChild('ticketContent1', { static: false }) ticketContent!: ElementRef;
      @ViewChild('ticketButton1', { static: false }) ticketButton!: ElementRef;
      @ViewChild('ticketLink',{static:false})ticketLink!:ElementRef;
downloadPdf() {
  const node = this.ticketContent.nativeElement;
  const button = this.ticketButton.nativeElement;
  const link=this.ticketLink.nativeElement;
  const originalDisplay = button.style.display;
  button.style.display = 'none';
  link.style.display='none';
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
