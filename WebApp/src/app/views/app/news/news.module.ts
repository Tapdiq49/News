import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-owl-carousel-o';

import { NewsRoutingModule } from './news-routing.module';
import { NewsComponent } from './news.component';
import { SliderComponent } from './slider/slider.component';


@NgModule({
  declarations: [
    NewsComponent,
    SliderComponent
  ],
  imports: [
    CommonModule,
    NewsRoutingModule,
    CarouselModule
  ]
})
export class NewsModule { }
