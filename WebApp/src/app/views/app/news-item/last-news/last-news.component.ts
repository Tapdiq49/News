import { Component, OnInit } from '@angular/core';
import { INewsItem } from 'src/app/shared/models/newsItem.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-last-news',
  templateUrl: './last-news.component.html',
  styleUrls: ['./last-news.component.scss']
})
export class LastNewsComponent implements OnInit {
  lastNews: INewsItem[] = [];
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getLastNews();
  }
  private getLastNews():void {
    this.apiService.getLastNews(4).subscribe(
      lastNews => {
        this.lastNews = lastNews;
        this.lastNews.forEach(element => {
          element.photos.forEach(photo => {
            if (photo.main) {
              element.mainPhoto = photo;
            }
          });
        });
      }
    );
  }
}
