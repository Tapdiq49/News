import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-owl-carousel-o';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavbarComponent } from './navbar/navbar.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { CategoryComponent } from './category/category.component';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { SearchComponent } from './search/search.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ContactUsComponent,
    CategoryComponent,
    SearchComponent
    
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    CarouselModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    ScrollingModule,
    MatProgressBarModule,
    FormsModule
  ]
})
export class AppModule { }
