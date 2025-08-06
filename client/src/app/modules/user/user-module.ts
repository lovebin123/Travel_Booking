import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing-module';
import { NgbActiveModal, NgbDatepicker, NgbDatepickerModule, NgbDropdownModule, NgbModalModule, NgbNavItem, NgbNavModule, NgbPopoverModule, NgbToast, NgbTooltipModule, NgbTypeaheadModule } from "@ng-bootstrap/ng-bootstrap";
import { FlightList } from './shared/Flights/flight-list/flight-list';
import { FlightBooking } from './features/flight-booking/flight-booking';
import { FlightDetails } from './shared/Flights/flight-details/flight-details';
import { FlightBaggage } from './shared/Flights/flight-baggage/flight-baggage';
import { FlightUser } from './shared/Flights/flight-user/flight-user';
import { AdminModule } from '../admin/admin-module';
import { FlightSearch } from './shared/Flights/flight-search/flight-search';
import { FormsModule } from '@angular/forms';
import { FlightFrom } from './shared/Flights/searchComponent/flight-from/flight-from';
import { FlightTo } from './shared/Flights/searchComponent/flight-to/flight-to';
import { FlightDestinationDate } from './shared/Flights/searchComponent/flight-destination-date/flight-destination-date';
import { FlightPassenger } from './shared/Flights/searchComponent/flight-passenger/flight-passenger';
import { UserLayout } from './shared/user-layout/user-layout';
import { FlightHome } from './features/flight-home/flight-home';
import { FlightTicket } from './features/flight-ticket/flight-ticket';
import { FligtCard } from './shared/Flights/fligt-card/fligt-card';
import { FlightTicketUser } from './shared/Flights/flight-ticket-user/flight-ticket-user';
import { FlightSeat } from './shared/Flights/flight-seat/flight-seat';
import { FlightTicketPayment } from './shared/Flights/flight-ticket-payment/flight-ticket-payment';
import { TransactionsLayout } from './shared/transactions-layout/transactions-layout';
import { Profile } from './features/profile/profile';
import { FligthtTransactions } from './features/fligtht-transactions/fligtht-transactions';
import { FlightBookingTransactions } from './features/fligtht-transactions/flight-booking-transactions/flight-booking-transactions';
import { HotelList } from './shared/hotels/hotel-list/hotel-list';
import { HotelBookingModal } from './features/hotel-booking-modal/hotel-booking-modal';
import { HotelSearch } from './shared/hotels/hotel-search/hotel-search';
import { HotelLocation } from './shared/hotels/search-component/hotel-location/hotel-location';
import { HotelCheckin } from './shared/hotels/search-component/hotel-checkin/hotel-checkin';
import { HotelCheckout } from './shared/hotels/search-component/hotel-checkout/hotel-checkout';
import { HotelAdultsRooms } from './shared/hotels/search-component/hotel-adults-rooms/hotel-adults-rooms';
import { HotelDetails } from './shared/hotels/hotel-details/hotel-details';
import { HotelCheckinCheckout } from './shared/hotels/hotel-checkin-checkout/hotel-checkin-checkout';
import { HotelServices } from './shared/hotels/hotel-services/hotel-services';
import { HotelUser } from './shared/hotels/hotel-user/hotel-user';
import { HotelHomePage } from './features/hotel-home-page/hotel-home-page';
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { TransactionTabs } from './shared/transaction-tabs/transaction-tabs';
import { HotelTicket } from './features/hotel-ticket/hotel-ticket';
import { HotelTicketDetails } from './shared/hotels/hotel-ticket-details/hotel-ticket-details';
import { HotelPaymentDetails } from './shared/hotels/hotel-payment-details/hotel-payment-details';
import { HotelServiceList } from './shared/hotels/hotel-service-list/hotel-service-list';
import { HotelTransactions } from './features/hotel-transactions/hotel-transactions';
import { HotelBookingTransaction } from './features/hotel-transactions/hotel-booking-transaction/hotel-booking-transaction';
import { CarRental } from './features/car-rental/car-rental';
import { CarRentalSearch } from './shared/carRental/car-rental-search/car-rental-search';
import { CarRentalPickUpLocation } from './shared/carRental/search-component/car-rental-pick-up-location/car-rental-pick-up-location';
import { CarRentalPickUpDate } from './shared/carRental/search-component/car-rental-pick-up-date/car-rental-pick-up-date';
import { CarRentalDropOffDate } from './shared/carRental/search-component/car-rental-drop-off-date/car-rental-drop-off-date';
import { CarRentalDropOffTime } from './shared/carRental/search-component/car-rental-drop-off-time/car-rental-drop-off-time';
import { CarRentalPickUpTime } from './shared/carRental/search-component/car-rental-pick-up-time/car-rental-pick-up-time';
import { CarRentalList } from './shared/carRental/car-rental-list/car-rental-list';
import { CarRentalBookingModal } from './features/car-rental-booking-modal/car-rental-booking-modal';
import { CarRentalDetails } from './shared/carRental/car-rental-details/car-rental-details';
import { CarRentalServices } from './shared/carRental/car-rental-services/car-rental-services';
import { CarRentalUser } from './shared/carRental/car-rental-user/car-rental-user';
import { CarRentalTransactions } from './features/car-rental-transactions/car-rental-transactions';
import { CarRentalBookingTransaction } from './features/car-rental-transactions/car-rental-booking-transaction/car-rental-booking-transaction';
import { CarRentalTicket } from './features/car-rental-ticket/car-rental-ticket';
import { CarRentalTicketDetails } from './shared/carRental/car-rental-ticket-details/car-rental-ticket-details';
import { CarRentalPaymentDetails } from './shared/carRental/car-rental-payment-details/car-rental-payment-details';
import { CarRentalServiceList } from './shared/carRental/car-rental-service-list/car-rental-service-list';
import { Nav } from "../../common/components/nav/nav";
import { NavTabs } from "../../common/components/nav-tabs/nav-tabs";
import { FlightAdminAddDeleteModal } from './shared/Flights/flight-admin-add-delete-modal/flight-admin-add-delete-modal';
import { FlightAdminDeleteAdmin } from './shared/Flights/flight-admin-delete-admin/flight-admin-delete-admin';
import { HotelAdminDeleteModal } from './shared/hotels/hotel-admin-delete-modal/hotel-admin-delete-modal';
import { HotelAdminAddUpdateModal } from './shared/hotels/hotel-admin-add-update-modal/hotel-admin-add-update-modal';
import { CarRentalAdminDelete } from './shared/carRental/car-rental-admin-delete/car-rental-admin-delete';
import { CarRemtalAddUpdateModal } from './shared/carRental/car-remtal-add-update-modal/car-remtal-add-update-modal';

@NgModule({
  declarations: [
    FlightList,FlightBooking,FlightList,FlightDetails, FlightBaggage, FlightUser, FlightSearch,FlightFrom, FlightTo, FlightDestinationDate, FlightPassenger, UserLayout, FlightHome,FlightTicket, FligtCard, FlightTicketUser, FlightSeat, FlightTicketPayment, TransactionsLayout, Profile, FligthtTransactions, FlightBookingTransactions, HotelList, HotelBookingModal, HotelSearch, HotelLocation, HotelCheckin, HotelCheckout, HotelAdultsRooms, HotelDetails, HotelCheckinCheckout, HotelServices, HotelUser, HotelHomePage,
TransactionTabs, HotelTicket, HotelTicketDetails, HotelPaymentDetails, HotelServiceList, HotelTransactions, HotelBookingTransaction, CarRental, CarRentalSearch, CarRentalPickUpLocation, CarRentalPickUpDate, CarRentalDropOffDate, CarRentalDropOffTime, CarRentalPickUpTime, CarRentalList, CarRentalBookingModal, CarRentalDetails, CarRentalServices, CarRentalUser, CarRentalTransactions,CarRentalBookingTransaction, CarRentalTicket, CarRentalTicketDetails, CarRentalPaymentDetails, CarRentalServiceList,FlightAdminAddDeleteModal,FlightAdminDeleteAdmin,HotelAdminDeleteModal,HotelAdminAddUpdateModal,
CarRentalAdminDelete,HotelAdminDeleteModal,HotelAdminAddUpdateModal,CarRemtalAddUpdateModal,CarRentalAdminDelete
  ],
  imports: [
    CommonModule, UserRoutingModule,
    NgbToast, CommonModule, FormsModule, NgbPopoverModule, NgbTypeaheadModule, NgbDatepickerModule,
    NgbModalModule, NgbNavModule, NgbTooltipModule,
    FontAwesomeModule, NgbDropdownModule, NgbNavItem,
    Nav,
    NavTabs,
],
exports:[FlightList,HotelList,CarRentalList,FlightAdminAddDeleteModal,FlightAdminDeleteAdmin,CarRentalAdminDelete,HotelAdminDeleteModal,HotelAdminAddUpdateModal,CarRemtalAddUpdateModal,CarRentalAdminDelete]
})
export class UserModule { }
