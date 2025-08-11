import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jsPDF from 'jspdf';
import domtoimage from 'dom-to-image';
import { CarRentalPaymentService } from '../../../../common/services/CarRental/CarRentalPayment/car-rental-payment.service';
@Component({
  selector: 'app-car-rental-ticket',
  standalone: false,
  templateUrl: './car-rental-ticket.html',
  styleUrl: './car-rental-ticket.css'
})
export class CarRentalTicket implements OnInit {
constructor(private carRental:CarRentalPaymentService,private route:ActivatedRoute,private router:Router){
   const navigation=this.router.getCurrentNavigation();
   const state=navigation?.extras?.state as {id:any};
   if(state?.id)
   {
    this.id=state?.id;
   }
  }
  backHome()
  {
    this.router.navigate(['/transactions'],{state:{status:"Success"}});
  }
  ngOnInit(): void {
    if(this.id===undefined)
    {
        const sessionId=this.route.snapshot.paramMap.get('sessionID');
      this.carRental.getLatestPayment(sessionId).subscribe({
        next:(response)=>{
          this.data=response.result;
        }
      })
    }
    else{
    this.carRental.getById(this.id).subscribe({
      next:(response)=>{
        this.data=response.result;
      }
    });
    }
  }
    data:any={};
      id:any;
      @ViewChild('ticketContent',{static:false})ticketContent!:ElementRef;
      @ViewChild('ticketBtn',{static:false})ticketBtn!:ElementRef;
      @ViewChild('ticketLink',{static:false})ticketLink!:ElementRef;
  downloadPdf() {
    const node = this.ticketContent.nativeElement;
    const button = this.ticketBtn.nativeElement;
    const originalDisplay = button.style.display;
    const link=this.ticketLink.nativeElement;
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
        doc.save(`CarRental_${this.data.stripe_payement_intent_id}.pdf`);
        button.style.display = originalDisplay;
      };
    }).catch((error) => {
      console.error("Error generating PDF", error);
      button.style.display = originalDisplay;
    });
  }
}
