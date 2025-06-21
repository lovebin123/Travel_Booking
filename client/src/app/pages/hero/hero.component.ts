import { FlightHomeComponent } from '../Flights/flight-home/flight-home.component';
import { Component, OnInit } from '@angular/core';
import {faUser,faSuitcase,faUserCircle} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/Account/auth.service';
import { HotelHomePageComponent } from '../Hotels/hotel-home-page/hotel-home-page.component';
import { CarRentalHomePageComponent } from '../CarRental/car-rental-home-page/car-rental-home-page.component';
import { NavComponent } from "../../components/nav/nav.component";
import { TabsComponent } from "../../components/nav-tabs/tabs.component";
@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [FontAwesomeModule, FlightHomeComponent, HotelHomePageComponent, CarRentalHomePageComponent, FlightHomeComponent, NavComponent, TabsComponent],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.scss'
})
export class HeroComponent implements OnInit {
  faUser=faUser;
  faUserCircle=faUserCircle;
  faSuitcase=faSuitcase;
  firstName:any='';
  data:any=[];
  constructor(private router:Router,private auth:AuthService){
  }
  ngOnInit(): void {
  this.auth.getUserName().subscribe((response)=>{
   this.data=response;
      this.firstName=this.data.firstName;
  }
    );
  
  }
  logout()
  {
    this.auth.logout();
  }

}
function ngOnInit() {
  throw new Error('Function not implemented.');
}

