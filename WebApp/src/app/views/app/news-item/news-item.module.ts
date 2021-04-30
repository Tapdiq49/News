import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewsItemRoutingModule } from './news-item-routing.module';
import { NewsItemComponent } from './news-item.component';
import { LastNewsComponent } from './last-news/last-news.component';
import { ContactInfoComponent } from './contact-info/contact-info.component';



@NgModule({
  declarations: [
    NewsItemComponent,
    LastNewsComponent,
    ContactInfoComponent
  ],
  imports: [
    CommonModule,
    NewsItemRoutingModule
  ]
})
export class NewsItemModule { }
