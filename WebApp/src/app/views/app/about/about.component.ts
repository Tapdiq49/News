import { Component, OnInit } from '@angular/core';
import { IAbout } from 'src/app/shared/models/about.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  public about:IAbout = {
    "title": "", "text": ""
  };
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getAbout();
  }
  getAbout():void{
    this.apiService.getAbout().subscribe(
      about=>{
        this.about = about;
      }
    )
  }

}
