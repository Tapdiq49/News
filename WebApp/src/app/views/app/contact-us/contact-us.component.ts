import { Component, OnInit } from '@angular/core';
import { IContact } from 'src/app/shared/models/contact.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent implements OnInit {
  public contact:IContact = {
    "phone": "", "email": "", "address": ""
  };
  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.getContact();
  }

  getContact():void{
    this.apiService.getContact().subscribe(
      contact=>{
        this.contact = contact;
      }
    )
  }
}
