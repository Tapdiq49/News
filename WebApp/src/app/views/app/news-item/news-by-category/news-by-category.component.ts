import { SimpleChanges } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { INewsList } from 'src/app/shared/models/news.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-news-by-category',
  templateUrl: './news-by-category.component.html',
  styleUrls: ['./news-by-category.component.scss']
})
export class NewsByCategoryComponent implements OnInit {
  @Input() cat: number = 0;
  private currentCount = 0;
  public news: INewsList = {
    "news": [], "count": 0
  };
  constructor(private apiService: ApiService) {

  }

  ngOnInit(): void {
    this.getNews();
  }
  ngOnChanges(changes: SimpleChanges) {
    this.getNews();
  }
  private getNews(): void {


    this.apiService.getCategoryNews(this.cat, this.currentCount).subscribe(
      news => {
        news.news.forEach(element => {
          element.photos.forEach(photo => {
            if (photo.main) {
              element.mainPhoto = photo;
            }
          });
        });

        this.news.news = news.news;

        this.news.count = news.count;
      }
    )



  }
  public newsLike(newsId: number): void {
    this.apiService.newsLike(newsId, null).subscribe(
      newsItem => {
        this.news.news.forEach(element => {
          if (element.id == newsId) {
            element.like = newsItem.like;
            element.liked = true;
          }
        })
      }
    )
  }
  public newsDislike(newsId: number): void {
    this.apiService.newsDislike(newsId, null).subscribe(
      newsItem => {
        this.news.news.forEach(element => {
          if (element.id == newsId) {
            element.dislike = newsItem.dislike;
            element.disliked = true;
          }
        })
      }
    )
  }
}
