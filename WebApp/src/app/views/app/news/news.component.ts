import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { INewsList } from 'src/app/shared/models/news.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  public categoryId: number = 0;
  public news: INewsList = {
    "news": [], "count": 0
  };
  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(params => {
      this.categoryId = Number(params.categoryId);
      this.getNews();
    })

  }

  ngOnInit(): void {
  }

  private getNews(): void {
    if (this.categoryId == 0) {
      this.apiService.getNews(0).subscribe(
        news => {
          this.news = news;
          this.news.news.forEach(element => {
            element.photos.forEach(photo => {
              if (photo.main) {
                element.mainPhoto = photo;
              }
            });
          });
        }
      )
    }else{
      this.apiService.getCategoryNews(this.categoryId,0).subscribe(
        news => {
          this.news = news;
          this.news.news.forEach(element => {
            element.photos.forEach(photo => {
              if (photo.main) {
                element.mainPhoto = photo;
              }
            });
          });
        }
      )
    }
  }

}
