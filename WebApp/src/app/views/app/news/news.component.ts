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
  private currentCount = 0;
  public categoryId: number = 0;
  public searchText: string = "";
  public news: INewsList = {
    "news": [], "count": 0
  };
  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(params => {
      this.categoryId = Number(params.categoryId);
      this.searchText = params.search;

      this.getNews();
    })

  }

  ngOnInit(): void {
  }

  private getNews(): void {
    if(this.searchText){
      this.apiService.search(this.searchText,this.currentCount).subscribe(
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
      if (this.categoryId == 0) {
        this.apiService.getNews(this.currentCount).subscribe(
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
        this.apiService.getCategoryNews(this.categoryId,this.currentCount).subscribe(
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

  public newsLike(newsId: number):void {
    this.apiService.newsLike(newsId, null).subscribe(
      newsItem => {
        this.news.news.forEach(element => {
          if(element.id == newsId){
            element.like = newsItem.like;
          }
        })
      }
    )
  }
  public newsDislike(newsId: number):void {
    this.apiService.newsDislike(newsId, null).subscribe(
      newsItem => {
        this.news.news.forEach(element => {
          if(element.id == newsId){
            element.dislike = newsItem.dislike;
          }
        })
      }
    )
  }

  
}
