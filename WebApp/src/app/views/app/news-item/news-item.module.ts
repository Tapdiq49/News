import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewsItemRoutingModule } from './news-item-routing.module';
import { NewsItemComponent } from './news-item.component';
import { LastNewsComponent } from './last-news/last-news.component';



@NgModule({
  declarations: [
    NewsItemComponent,
    LastNewsComponent
  ],
  imports: [
    CommonModule,
    NewsItemRoutingModule
  ]
})
export class NewsItemModule { }
