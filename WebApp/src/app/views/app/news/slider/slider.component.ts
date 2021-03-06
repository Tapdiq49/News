import { Component, OnInit } from '@angular/core';
import { INewsItem } from 'src/app/shared/models/newsItem.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {
  newsSlider: INewsItem[] = [];
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getSliderNews();
  }

  customOptions: any = {
    loop: true,
    autoplay:true,
    autoplayTimeout:5000,
    autoplayHoverPause:false,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: true,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      1000: {
        items: 1
      }
    },
    nav: true
  }
  private getSliderNews():void {
    this.apiService.getSliderNews().subscribe(
      newsSlider => {
        this.newsSlider = newsSlider;
        this.newsSlider.forEach(element => {
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
