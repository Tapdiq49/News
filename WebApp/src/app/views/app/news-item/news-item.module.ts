import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewsItemRoutingModule } from './news-item-routing.module';
import { NewsItemComponent } from './news-item.component';



@NgModule({
  declarations: [
    NewsItemComponent
  ],
  imports: [
    CommonModule,
    NewsItemRoutingModule
  ]
})
export class NewsItemModule { }
