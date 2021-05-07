import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { ICategory } from 'src/app/shared/models/category.model';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-category-navbar',
  templateUrl: './category-navbar.component.html',
  styleUrls: ['./category-navbar.component.scss']
})
export class CategoryNavbarComponent {
  categories: ICategory[] = [];

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
    ngOnInit(): void {
      this.getCategories();
    }

  constructor(private breakpointObserver: BreakpointObserver,private apiService: ApiService) {}
  private getCategories():void {
    this.apiService.getCategories().subscribe(
      categories => {
        this.categories = categories;
      }
    );
  }
  public close():void {
    
  }
}
