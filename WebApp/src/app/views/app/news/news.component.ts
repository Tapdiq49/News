import { Component, Input, OnInit } from '@angular/core';
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
      this.currentCount = 0;
      this.getNews(false);
      if(!this.searchText){
        (<HTMLInputElement>document.getElementById("newsSearch")).value="";
      }
    })

  }

  ngOnInit(): void {
  }

  private getNews(paginationUpdate : boolean): void {
    if(this.searchText){
      this.apiService.search(this.searchText,this.currentCount).subscribe(
        news => {
          news.news.forEach(element => {
            element.photos.forEach(photo => {
              if (photo.main) {
                element.mainPhoto = photo;
              }
            });
          });
          if(paginationUpdate){
            this.news.news = this.news.news.concat(news.news) ;
          }else{
            this.news.news = news.news;
          }
          this.news.count = news.count;
        }
      )
    }else{
      if (this.categoryId == 0) {
        this.apiService.getNews(this.currentCount).subscribe(
          news => {
            news.news.forEach(element => {
              element.photos.forEach(photo => {
                if (photo.main) {
                  element.mainPhoto = photo;
                }
              });
            });
            if(paginationUpdate){
              this.news.news = this.news.news.concat(news.news) ;
            }else{
              this.news.news = news.news;
            }
            this.news.count = news.count;
          }
        )
      }else{
        this.apiService.getCategoryNews(this.categoryId,this.currentCount).subscribe(
          news => {
            news.news.forEach(element => {
              element.photos.forEach(photo => {
                if (photo.main) {
                  element.mainPhoto = photo;
                }
              });
            });
            if(paginationUpdate){
              this.news.news = this.news.news.concat(news.news) ;
            }else{
              this.news.news = news.news;
            }
            this.news.count = news.count;
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
            element.liked = true;
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
            element.disliked = true;
          }
        })
      }
    )
  }

  public changeCount():void{
    this.currentCount = this.news.count;
    this.getNews(true);
  }
}
