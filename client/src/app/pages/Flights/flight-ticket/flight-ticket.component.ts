import { Component, ElementRef, ViewChild } from '@angular/core';
import { FlightPaymentService } from '../../../services/Flights/FlightPayment/flight-payment.service';
import { FlightBaggageComponent } from "../../../components/modals/flights/flight-baggage/flight-baggage.component";
import { NavComponent } from "../../../components/nav/nav.component";
import jsPDF, { RGBAData } from 'jspdf';
import domtoimage from 'dom-to-image';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FlightTicketUserComponent } from '../../../components/cards/Flights/flight-ticket-user/flight-ticket-user.component';
import { FlightSeatComponent } from '../../../components/cards/Flights/flight-seat/flight-seat.component';
import { FlightTicketPaymentComponent } from '../../../components/cards/Flights/flight-ticket-payment/flight-ticket-payment.component';
import { FligtCardComponent } from '../../../components/cards/Flights/fligt-card/fligt-card.component';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-flight-ticket',
  standalone: true,
  imports: [FligtCardComponent, FlightTicketUserComponent, FlightBaggageComponent, FlightSeatComponent, FlightTicketPaymentComponent, FontAwesomeModule],
  templateUrl: './flight-ticket.component.html',
  styleUrl: './flight-ticket.component.scss'
})
export class FlightTicketComponent {
    @ViewChild('ticketContent', { static: false }) ticketContent!: ElementRef;
    @ViewChild('ticketButton', { static: false }) ticketButton!: ElementRef;
    @ViewChild('backHome',{static:false}) backHome!:ElementRef;
 paymentDetails={paymen_id:'',card_type:'',amount:''};
  data:any={};
  flightDetails:any=[];
  userDetails:any[]=[];
  sessionId:any;
  id:any;
  constructor(private flightPayment:FlightPaymentService,private router:Router,private route:ActivatedRoute){
     const navigation = this.router.getCurrentNavigation();
const state = navigation?.extras?.state as { id: any };

if (state?.id) {
  this.id = state.id;
  console.log(this.id);
}
else{
      const mail=localStorage.getItem('token');
      if(mail)
        this.id=state?.id;
    }
  }
  ngOnInit(): void {
         this.sessionId=this.route.snapshot.paramMap.get('sessionID');
  if(this.id===undefined)
  {
    console.log(this.sessionId);
   this.flightPayment.getLastPayement(this.sessionId).subscribe((response:any)=>{
    this.data=response.result;
    this.flightDetails=this.data.flightBooking.flight;
    this.userDetails=this.data.flightBooking.appUser;
    this.paymentDetails.paymen_id=this.data.stripe_payement_intent_id;
    this.paymentDetails.amount=this.data.amount;
    this.paymentDetails.card_type=this.data.card;
   })
  }
  else{
        console.log(this.id);
    this.flightPayment.getByid(this.id).subscribe((response:any)=>{
      console.log(response);
      this.data=response.result;
    this.flightDetails=this.data.flightBooking.flight;
    this.userDetails=this.data.flightBooking.appUser;
    this.paymentDetails.paymen_id=this.data.stripe_payement_intent_id;
    this.paymentDetails.amount=this.data.amount;
    this.paymentDetails.card_type=this.data.card;
    })
  }
  }
downloadPdf() {
  const node = this.ticketContent.nativeElement;
  const button = this.ticketButton.nativeElement;
  const link=this.backHome.nativeElement;
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
      doc.addImage(dataUrl, 'PNG', 10, 10, width, height);
      doc.save(`Flight_Ticket_${this.data.stripe_payement_intent_id}.pdf`);
      button.style.display = originalDisplay;
    };
  }).catch((error) => {
    console.error("Error generating PDF", error);
    button.style.display = originalDisplay;
  });
}
}
