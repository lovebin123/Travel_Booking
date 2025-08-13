import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HotelServiceService } from '../../../../common/services/Hotels/hotel-service.service';

@Component({
  selector: 'app-hotel-admin',
  standalone: false,
  templateUrl: './hotel-admin.html',
  styleUrl: './hotel-admin.css'
})
export class HotelAdmin implements OnInit {
  data: any = [];
  searchQuery: any;
  constructor(private hotel: HotelServiceService) { }
  additionSuccessfull = false;
  modal = inject(NgbModal);
  totalRecords = 0;
  pageSize = 6;
  page = 1;
  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    this.hotel.getAllHotels(this.page, this.pageSize).subscribe({
      next: (response: any) => {
        this.data = response.result.hotels;
        this.totalRecords = response.result.totalCount;
      }
    })
  }
  handleChange(event: any) {
    this.loadData();
  }
  onPageChange(page: number) {
    this.page = page;
    this.loadData();
  }
  addHotels(content: TemplateRef<any>) {
    const modalRef = this.modal.open(content, { centered: true, size: 'lg' });
    modalRef.result.catch((response) => {
      this.additionSuccessfull = response;
    })
  }
  searchByHotelName() {
    this.hotel.searchByHotelName(this.searchQuery).subscribe({
      next: (response: any) => {
        response = response.result;
        this.data = response;
      }
    }
    )
  }
}
