import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLayout } from './shared/user-layout/user-layout';
import { TransactionsLayout } from './shared/transactions-layout/transactions-layout';
import { FlightTicket } from './features/flight-ticket/flight-ticket';
import { HotelTicket } from './features/hotel-ticket/hotel-ticket';
import { CarRentalTicket } from './features/car-rental-ticket/car-rental-ticket';
import { authGuardGuard } from '../../common/guards/auth.guard';
import { userGuardGuard } from '../../common/guards/user.guard';

const routes: Routes = [{
    path:'',component:UserLayout,
},
{path:'transactions',component:TransactionsLayout,canActivate:[authGuardGuard,userGuardGuard]},
{path:'flightTicket',component:FlightTicket,canActivate:[authGuardGuard]},
{path:'flightTicket/:sessionID',component:FlightTicket,canActivate:[authGuardGuard]},
{path:'hotelTicket/:sessionID',component:HotelTicket,canActivate:[authGuardGuard]},
{path:'hotelTicket',component:HotelTicket,canActivate:[authGuardGuard]},
{path:'carRentalTicket',component:CarRentalTicket,canActivate:[authGuardGuard]},
{path:'carRentalTicket/:sessionID',component:CarRentalTicket,canActivate:[authGuardGuard]}]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
