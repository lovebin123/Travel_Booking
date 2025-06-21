import { Component, OnInit } from '@angular/core';
import { NavComponent } from "../../components/nav/nav.component";
import { TransactionTabsComponent } from "../../components/transaction-tabs/transaction-tabs.component";
import { AuthService } from '../../services/Account/auth.service';
import { FlightAdminComponent } from "../Flights/flight-admin/flight-admin.component";
import { HotelAdminComponent } from "../Hotels/hotel-admin/hotel-admin.component";
import { AdminTabsComponent } from "../../components/admin-tabs/admin-tabs.component";
import { CarRentalAdminComponent } from "../CarRental/car-rental-admin/car-rental-admin.component";

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [NavComponent, TransactionTabsComponent, FlightAdminComponent, HotelAdminComponent, AdminTabsComponent, CarRentalAdminComponent],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.scss'
})
export class AdminDashboardComponent implements OnInit{
  constructor(private auth:AuthService){}
  ngOnInit(): void {
    this.firstName=this.auth.getUserName().subscribe({
      next:(response:any)=>{
        this.firstName=response.firstName;
      }
    })
  }
firstName: any;


}
