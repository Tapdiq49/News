import { Component, OnInit } from '@angular/core';
import { INewsSlider } from 'src/app/shared/models/slider.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {
  newsSlider: INewsSlider[] = [];
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getSliderNews();
  }

  customOptions: any = {
    loop: true,
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
