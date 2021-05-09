import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/shared/models/category.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  categories: ICategory[] = [];
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getCategories();
  }
  openMenu(event: Event) { 
    document.getElementsByClassName("navbar-menus")[0].classList.add("show");
  }
  closeMenu(event: Event) { 
    document.getElementsByClassName("navbar-menus")[0].classList.remove("show");
  }
  private getCategories():void {
    this.apiService.getCategories().subscribe(
      categories => {
        this.categories = categories;
      }
    );
  }
}

