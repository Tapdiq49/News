import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-owl-carousel-o';

import { NewsRoutingModule } from './news-routing.module';
import { NewsComponent } from './news.component';
import { SliderComponent } from './slider/slider.component';
import { LastNewsComponent } from './last-news/last-news.component';


@NgModule({
  declarations: [
    NewsComponent,
    SliderComponent,
    LastNewsComponent
  ],
  imports: [
    CommonModule,
    NewsRoutingModule,
    CarouselModule
  ],
  exports:[
    NewsComponent
  ]
})
export class NewsModule { }
