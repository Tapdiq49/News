import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewsItemRoutingModule } from './news-item-routing.module';
import { NewsItemComponent } from './news-item.component';
import { CommentComponent } from './comment/comment.component';


@NgModule({
  declarations: [
    NewsItemComponent,
    CommentComponent
  ],
  imports: [
    CommonModule,
    NewsItemRoutingModule
  ]
})
export class NewsItemModule { }
