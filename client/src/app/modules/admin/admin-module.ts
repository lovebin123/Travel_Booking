import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing-module';
import { FlightAdminAddDeleteModal } from '../user/shared/Flights/flight-admin-add-delete-modal/flight-admin-add-delete-modal';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbModule, NgbPagination, NgbToast } from '@ng-bootstrap/ng-bootstrap';
import { FlightAdminDeleteAdmin } from '../user/shared/Flights/flight-admin-delete-admin/flight-admin-delete-admin';
import { HotelAdminAddUpdateModal } from '../user/shared/hotels/hotel-admin-add-update-modal/hotel-admin-add-update-modal';
import { HotelAdminDeleteModal } from '../user/shared/hotels/hotel-admin-delete-modal/hotel-admin-delete-modal';
import { CarRemtalAddUpdateModal } from '../user/shared/carRental/car-remtal-add-update-modal/car-remtal-add-update-modal';
import { CarRentalAdminDelete } from '../user/shared/carRental/car-rental-admin-delete/car-rental-admin-delete';
import { AdminDashboard } from './features/admin-dashboard/admin-dashboard';
import { Nav } from "../../common/components/nav/nav";
import { AdminTabs } from "../../common/components/admin-tabs/admin-tabs";
import { FlightAdmin } from './features/flight-admin/flight-admin';
import { HotelAdmin } from './features/hotel-admin/hotel-admin';
import { CarRentalAdmin } from './features/car-rental-admin/car-rental-admin';
import { FlightList } from '../user/shared/Flights/flight-list/flight-list';
import { HotelList } from '../user/shared/hotels/hotel-list/hotel-list';
import { CarRentalList } from '../user/shared/carRental/car-rental-list/car-rental-list';
import { UserModule } from "../user/user-module";


@NgModule({
  declarations: [
    AdminDashboard,
    FlightAdmin,
    HotelAdmin,
    CarRentalAdmin,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule, FormsModule, NgbDatepickerModule,
    NgbToast,
    Nav,
    AdminTabs,
    NgbPagination,
    UserModule
],
  exports:[]
})
export class AdminModule { }
