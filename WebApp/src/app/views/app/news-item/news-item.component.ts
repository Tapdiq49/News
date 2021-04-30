import { AfterViewChecked, OnInit } from '@angular/core';
import { INewsItem } from 'src/app/shared/models/newsItem.model';
import { ApiService } from 'src/app/shared/services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Component } from '@angular/core';

declare var FB: any;

@Component({
  selector: 'app-news-item',
  templateUrl: './news-item.component.html',
  styleUrls: ['./news-item.component.scss']
})
export class NewsItemComponent implements OnInit,AfterViewChecked {

  public window = window;

  public newsItemId: number = 0;

  public safeVideoLink: SafeResourceUrl = null;

  public newsItem: INewsItem = {
    "category": { name: "", id: 0 },
    "text": "",
    "title": "",
    "view": 0,
    "videoLink": "",
    "comment": false,
    "photos": [],
    "createdAt": new Date,
    "dislike": 0,
    "like": 0,
    "id": 0,
    "categoryId": 0,
    "mainPhoto" : { orderBy: 0, image: "", main : false, id: 0 },
    "noneMainPhotos" : []
  };
  constructor(private apiService: ApiService, private route: ActivatedRoute, public router: Router, 
    private _sanitizer: DomSanitizer ) {
    this.route.params.subscribe(params => {
      this.newsItemId = Number(params.newsItemId);
      this.getNewsById();          
    })
  }

  ngOnInit(): void {   
    
  }
  ngAfterViewChecked():void{
    if (typeof (FB) != 'undefined'&& FB != null) { FB.XFBML.parse(); }
  }


  private getNewsById(): void {
    this.apiService.getNewsById(this.newsItemId);
    this.apiService.getNewsById(this.newsItemId).subscribe(
      newsItem => {
        this.newsItem = newsItem;
        this.newsItem.noneMainPhotos = [];
        this.newsItem.photos.forEach(photo => {
          if (photo.main) {
            this.newsItem.mainPhoto = photo;
          }else{
            this.newsItem.noneMainPhotos.push(photo);
          }
        });
        if (this.newsItem.videoLink) {
          this.safeVideoLink = this._sanitizer.bypassSecurityTrustResourceUrl(this.newsItem.videoLink);
        }        
      }
    )

  }
}
