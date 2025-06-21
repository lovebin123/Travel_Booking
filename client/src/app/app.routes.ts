import { Routes } from '@angular/router';
import { LoginComponent } from './pages/Account/login/login.component';
import { SignupComponent } from './pages/Account/signup/signup.component';
import { ForgotPasswordComponent } from './pages/Account/forgot-password/forgot-password.component';
import { VerifyEmailComponent } from './pages/Account/verify-email/verify-email.component';
import { HeroComponent } from './pages/hero/hero.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';
import { FlightTicketComponent } from './pages/Flights/flight-ticket/flight-ticket.component';
import { PaymentFailureComponent } from './pages/payment-failure/payment-failure.component';
import { HotelTicketComponent } from './pages/Hotels/hotel-ticket/hotel-ticket.component';
import { CarRentalTicketPageComponent } from './pages/CarRental/car-rental-ticket-page/car-rental-ticket-page.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';
import { authGuardGuard } from './services/AuthGuard/auth-guard.guard';
import { userGuardGuard } from './services/AuthGuard/user-guard.guard';
import { adminGuard } from './services/AuthGuard/admin-guard.guard';
export const routes: Routes = [
    {path:'login',component:LoginComponent},
    {path:'signup',component:SignupComponent},
    {path:'admin',component:AdminDashboardComponent,canActivate:[authGuardGuard,adminGuard]},
    {path:'forgotPassword/:sessionID',component:ForgotPasswordComponent},
    {path:'verifyEmail',component:VerifyEmailComponent},
    {path:'hero',component:HeroComponent,canActivate:[authGuardGuard,userGuardGuard]},
    {path:'hotelTicket/:sessionID',component:HotelTicketComponent,canActivate:[authGuardGuard]},
    {path:'hotelTicket',component:HotelTicketComponent,canActivate:[authGuardGuard]},
    {path:'flightTicket/:sessionID',component:FlightTicketComponent,canActivate:[authGuardGuard]},
    {path:'flightTicket',component:FlightTicketComponent,canActivate:[authGuardGuard]},
    {path:'carRentalTicket',component:CarRentalTicketPageComponent,canActivate:[authGuardGuard]},
    {path:'carRentalTicket/:sessionID',component:CarRentalTicketPageComponent,canActivate:[authGuardGuard]},
    {path:'transactions',component:TransactionsComponent,canActivate:[authGuardGuard,userGuardGuard]},
    {path:'failure',component:PaymentFailureComponent},
    {path:'',redirectTo:'login',pathMatch:'full'},
    {path:'**',redirectTo:'login'},
];
